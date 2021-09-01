using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class DesperfectoRequestVM
    {
        [Display(Name = "Costo de mano de obra (en ARS$)")]
        [Required(ErrorMessage = "Dato obligatorio")]
        public double ManoDeObra { get; set; }
        [Display(Name = "Tiempo de trabajo (en días)")]
        [Required(ErrorMessage = "Dato obligatorio")]
        public double Tiempo { get; set; }
        [Required(ErrorMessage = "Dato obligatorio")]
        [Display(Name = "Vehículo")]
        public int Vehiculo { get; set; }
        [Display(Name = "Descuentos (en ARS$)")]
        public double? Descuentos { get; set; }
        [Display(Name = "Recargos (en ARS$)")]
        public double? Recargos { get; set; }
        public int[] Repuestos { get; set; }
    }
}
