using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class PresupuestoListVM
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Patente { get; set; }
        public double MontoTotal { get; set; }
    }
}
