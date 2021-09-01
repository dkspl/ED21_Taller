using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class PresupuestoDetailVM
    {
        public int Id { get; set; }
        public double ManoDeObra { get; set; }
        public double Estacionamiento { get; set; }
        public double Descuentos { get; set; }
        public double Recargos { get; set; }
        public double TotalRepuestos { get; set; }
        public double Total { get; set; }
        public DateTime Fecha { get; set; }
        public double Tiempo { get; set; }
        public VehiculoDetailVM Vehiculo { get; set; }
        public List<RepuestoDetailVM> Repuestos { get; set; } 
    }
}
