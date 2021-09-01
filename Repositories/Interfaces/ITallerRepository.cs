using Models.Entities;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ITallerRepository
    {
        int CreateAuto(Automovil auto);
        int CreateMoto(Moto moto);
        Vehiculo GetVehiculoById(int id);
        List<Vehiculo> GetVehiculos();
        Repuesto CreateRepuesto(Repuesto repuesto);
        Repuesto GetRepuestoById(int id);
        List<Repuesto> GetRepuestos();
        Presupuesto CreatePresupuesto(Desperfecto desperfecto, Presupuesto presupuesto);
        Presupuesto GetPresupuestoById(int id);
        List<RepuestoDesperfecto> GetRepuestosFrom(int desperfectoId);
        List<Presupuesto> ListPresupuestos();

    }
}
