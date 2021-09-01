using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class RepuestoDesperfecto
    {
        public int RepuestoId { get; set; }
        public int DesperfectoId { get; set; }
        public virtual Repuesto Repuesto { get; set; }
        public virtual Desperfecto Desperfecto { get; set; }
    }
}
