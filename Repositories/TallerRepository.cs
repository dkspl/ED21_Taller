using Models.Entities;
using Repositories.Interfaces;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ViewModels;

namespace Repositories
{
    public class TallerRepository : ITallerRepository
    {
        private readonly Context _context;
        public TallerRepository(Context context)
        {
            _context = context;
        }
        /*  Vehículo */
        public int CreateAuto(Automovil auto)
        {
            _context.Automoviles.Add(auto);
            _context.SaveChanges();
            return auto.Id;
        }
        public int CreateMoto(Moto moto)
        {
            _context.Motos.Add(moto);
            _context.SaveChanges();
            return moto.Id;
        }
        public Vehiculo GetVehiculoById(int id)
        {
            return _context.Vehiculos.Find(id);
        }
        public List<Vehiculo> GetVehiculos()
        {
            return _context.Vehiculos.ToList();
        }

        /*  Repuesto */
        public Repuesto CreateRepuesto(Repuesto repuesto)
        {
            _context.Repuestos.Add(repuesto);
            _context.SaveChanges();
            return repuesto;
        }
        public Repuesto GetRepuestoById(int id)
        {
            Repuesto repuestoEncontrado = _context.Repuestos.Find(id);
            return repuestoEncontrado;
        }
        public List<Repuesto> GetRepuestos()
        {
            return _context.Repuestos.ToList();
        }

        /*  Presupuesto */
        public int CreateDesperfecto(Desperfecto desperfecto)
        {
            _context.Desperfectos.Add(desperfecto);
            _context.SaveChanges();
            return desperfecto.Id;
        }
        public Presupuesto CreatePresupuesto(Desperfecto desperfecto, Presupuesto presupuesto)
        {
            int desperfectoId = this.CreateDesperfecto(desperfecto);
            presupuesto.DesperfectoId = desperfectoId;
            presupuesto.Fecha = DateTime.Now;
            _context.Presupuestos.Add(presupuesto);
            _context.SaveChanges();
            return presupuesto;
        }
        public Presupuesto GetPresupuestoById(int id)
        {
            Presupuesto presupuestoEncontrado = _context.Presupuestos.Find(id);
            return presupuestoEncontrado;
        }
        public List<RepuestoDesperfecto> GetRepuestosFrom(int desperfectoId)
        {
            return _context.RepuestosRequeridos.Where(d => d.DesperfectoId == desperfectoId).ToList();
        }
        public List<Presupuesto> ListPresupuestos()
        {
            return _context.Presupuestos.ToList();
        }
    }
}
