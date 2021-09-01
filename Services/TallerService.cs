using Models.Entities;
using Models.ViewModels;
using Repositories;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TallerService : ITallerService
    {
        private readonly ITallerRepository _tallerRepository;

        public TallerService(ITallerRepository repository)
        {
            _tallerRepository = repository;
        }
        /*  Vehículos   */
        public int CreateAuto(Automovil auto)
        {
            return _tallerRepository.CreateAuto(auto);
        }
        public int CreateMoto(Moto moto)
        {
            return _tallerRepository.CreateMoto(moto);
        }
        public List<Vehiculo> GetVehiculos()
        {
            return _tallerRepository.GetVehiculos();
        }
        public Vehiculo GetVehiculoById(int id)
        {
            return _tallerRepository.GetVehiculoById(id);
        }
        public bool ValidateVehiculo(int id)
        {
            Vehiculo vehiculo = this.GetVehiculoById(id);
            if (vehiculo == null)
                return false;
            return true;
        }
        /*  Repuestos   */
        public Repuesto CreateRepuesto(RepuestoDetailVM repuesto)
        {
            Repuesto repuestoNuevo = new Repuesto()
            {
                Nombre = repuesto.Nombre,
                Precio = repuesto.Precio
            };
            return _tallerRepository.CreateRepuesto(repuestoNuevo);
        }
        public Repuesto GetRepuestoById(int id)
        {
            return _tallerRepository.GetRepuestoById(id);
        }
        public List<Repuesto> GetRepuestos()
        {
            return _tallerRepository.GetRepuestos();
        }

        /*  Presupuestos   */
        public Presupuesto CreatePresupuesto(DesperfectoRequestVM arreglo)
        {
            Desperfecto desperfecto = this.GenerateDesperfecto(arreglo);
            Presupuesto presupuesto = this.GeneratePresupuesto(arreglo, desperfecto.Repuestos);
            return _tallerRepository.CreatePresupuesto(desperfecto, presupuesto);
        }
        public Presupuesto GeneratePresupuesto(DesperfectoRequestVM arreglo, ICollection<RepuestoDesperfecto> repuestos)
        {
            Presupuesto presupuesto = new Presupuesto()
            {
                Descuentos = arreglo.Descuentos == 0 ? 0 : arreglo.Descuentos * (-1),
                Recargos = arreglo.Recargos,
                ManoDeObra = arreglo.ManoDeObra
            };
            presupuesto.Estacionamiento = arreglo.Tiempo * 130;
            if(repuestos != null && repuestos.Count() > 0)
                presupuesto.Repuestos = this.SetPrecioRepuestos(repuestos);
            return presupuesto;
        }
        public Desperfecto GenerateDesperfecto(DesperfectoRequestVM arreglo)
        {
            Desperfecto desperfecto = new Desperfecto()
            {
                VehiculoId = arreglo.Vehiculo,
                Tiempo = arreglo.Tiempo,
            };
            desperfecto.Repuestos = this.SetListRepuestos(arreglo.Repuestos);
            return desperfecto;
        }
        public List<RepuestoDesperfecto> SetListRepuestos(int[] repuestos)
        {
            if (repuestos == null)
                return null;
            List<RepuestoDesperfecto> list = new List<RepuestoDesperfecto>();
            foreach (int repuesto in repuestos)
            {
                RepuestoDesperfecto nuevoRepuesto = new RepuestoDesperfecto()
                {
                    RepuestoId = repuesto,
                };
                list.Add(nuevoRepuesto);
            }
            return list;
        }
        public double SetPrecioRepuestos(ICollection<RepuestoDesperfecto> listaRepuestos)
        {
            double total = 0;
            foreach (RepuestoDesperfecto repuesto in listaRepuestos)
            {
                total += this.GetRepuestoById(repuesto.RepuestoId).Precio;
            }
            return total;
        }
        public double CalculateTotalPrice(Presupuesto presupuesto)
        {
            return (presupuesto.ManoDeObra + presupuesto.Estacionamiento +
                (double)presupuesto.Descuentos + (double)presupuesto.Recargos + (double)presupuesto.Repuestos) * 1.2;
        }
        public PresupuestoDetailVM GetPresupuestoDetail(int id)
        {
            Presupuesto presupuestoEncontrado = this.GetPresupuestoById(id);
            if (presupuestoEncontrado == null)
                return null;
            return this.SetPresupuestoDetail(presupuestoEncontrado);
        }
        public PresupuestoDetailVM SetPresupuestoDetail(Presupuesto presupuesto)
        {
            PresupuestoDetailVM presupuestoVM = new PresupuestoDetailVM()
            {
                Id = presupuesto.Id,
                Fecha = presupuesto.Fecha,
                Descuentos = (double)presupuesto.Descuentos,
                Recargos = (double)presupuesto.Recargos,
                Estacionamiento = presupuesto.Estacionamiento,
                ManoDeObra = presupuesto.ManoDeObra,
                TotalRepuestos = (double)presupuesto.Repuestos,
                Total = this.CalculateTotalPrice(presupuesto)
            };

            presupuestoVM.Vehiculo = new VehiculoDetailVM()
            {
                Patente = presupuesto.Desperfecto.Vehiculo.Patente,
                Marca = presupuesto.Desperfecto.Vehiculo.Marca,
                Modelo = presupuesto.Desperfecto.Vehiculo.Modelo
            };

            presupuestoVM.Repuestos = this.ListRepuestosFrom(presupuesto.DesperfectoId);
            return presupuestoVM;
        }
        public List<Presupuesto> GetPresupuestos()
        {
            return _tallerRepository.ListPresupuestos()
                .OrderByDescending(d => d.Fecha).ToList();
        }
        public List<RepuestoDetailVM> ListRepuestosFrom(int desperfectoId)
        {
            List<RepuestoDesperfecto> listJoin = _tallerRepository.GetRepuestosFrom(desperfectoId);
            List<RepuestoDetailVM> repuestos = new List<RepuestoDetailVM>();
            foreach (RepuestoDesperfecto repuesto in listJoin)
            {

                repuestos.Add(new RepuestoDetailVM()
                {
                    Nombre = repuesto.Repuesto.Nombre,
                    Precio = repuesto.Repuesto.Precio
                });
            }
            return repuestos;
        }
        public Presupuesto GetPresupuestoById(int id)
        {
            return _tallerRepository.GetPresupuestoById(id);
        }
        public List<PresupuestoListVM> ListPresupuestos(List<Presupuesto> presupuestos)
        {
            List<PresupuestoListVM> listaView = new List<PresupuestoListVM>();
            foreach (Presupuesto presupuesto in presupuestos)
            {
                PresupuestoListVM presupuestoVM = new PresupuestoListVM()
                {
                    Id = presupuesto.Id,
                    Fecha = presupuesto.Fecha,
                    Patente = presupuesto.Desperfecto.Vehiculo.Patente
                };
                presupuestoVM.MontoTotal = this.CalculateTotalPrice(presupuesto);
                listaView.Add(presupuestoVM);
            }
            return listaView;
        }  
    }
}
