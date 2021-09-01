using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Desperfecto
    {
        public int Id { get; set; }
        [Display(Name = "Tiempo de trabajo (en días)")]
        [Required(ErrorMessage = "Dato obligatorio")]
        public double Tiempo { get; set; }
        [Display(Name = "Vehículo")]
        [Required(ErrorMessage = "Dato obligatorio")]
        public int VehiculoId { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
        public virtual Presupuesto Presupuesto { get; set; }
        public virtual ICollection<RepuestoDesperfecto> Repuestos { get; set; }
    }
}
