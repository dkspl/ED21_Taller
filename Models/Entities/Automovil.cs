using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("Automovil")]
    public class Automovil : Vehiculo
    {
        [Display(Name = "Tipo de automóvil")]
        [Required(ErrorMessage = "Dato obligatorio")]
        public TipoAutomovil Tipo { get; set; }
        [Display(Name = "Cantidad de puertas")]
        [Required(ErrorMessage = "Dato obligatorio")]
        public int CantidadPuertas { get; set; }
    }
}
