using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Repuesto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public virtual ICollection<RepuestoDesperfecto> RepuestosDesperfectos { get; set; }
    }
}
