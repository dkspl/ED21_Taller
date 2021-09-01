using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Presupuesto
    {
        public int Id { get; set; }
        [Display(Name = "Costo por mano de obra (en ARS$)")]
        [Required(ErrorMessage = "Dato obligatorio")]
        public double ManoDeObra { get; set; }
        [Display(Name = "Costo por días en estacionamiento (en ARS$)")]
        [Required(ErrorMessage = "Dato obligatorio")]
        public double Estacionamiento { get; set; }
        public double? Descuentos { get; set; }
        public double? Recargos { get; set; }
        [Display(Name = "Costo por repuestos (en ARS$)")]
        public double? Repuestos { get; set; }
        public DateTime Fecha { get; set; }
        public int DesperfectoId { get; set; }
        public virtual Desperfecto Desperfecto { get; set; }
    }
}
