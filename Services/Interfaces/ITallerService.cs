using Models.Entities;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITallerService
    {
        int CreateAuto(Automovil auto);
        int CreateMoto(Moto moto);
        Vehiculo GetVehiculoById(int id);
        List<Vehiculo> GetVehiculos();
        bool ValidateVehiculo(int id);
        Repuesto CreateRepuesto(RepuestoDetailVM repuesto);
        Repuesto GetRepuestoById(int id);
        List<Repuesto> GetRepuestos();
        Presupuesto CreatePresupuesto(DesperfectoRequestVM arreglo);
        Presupuesto GeneratePresupuesto(DesperfectoRequestVM arreglo, ICollection<RepuestoDesperfecto> repuestos);
        Desperfecto GenerateDesperfecto(DesperfectoRequestVM arreglo);
        List<RepuestoDesperfecto> SetListRepuestos(int[] repuestos);
        double SetPrecioRepuestos(ICollection<RepuestoDesperfecto> listaRepuestos);
        double CalculateTotalPrice(Presupuesto presupuesto);
        PresupuestoDetailVM GetPresupuestoDetail(int id);
        PresupuestoDetailVM SetPresupuestoDetail(Presupuesto presupuesto);
        List<Presupuesto> GetPresupuestos();
        List<RepuestoDetailVM> ListRepuestosFrom(int desperfectoId);
        Presupuesto GetPresupuestoById(int id);
        List<PresupuestoListVM> ListPresupuestos(List<Presupuesto> presupuestos);
    }
}
