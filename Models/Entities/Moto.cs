using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("Moto")]
    public class Moto : Vehiculo
    {
        [Display(Name = "Cilindrada (en cc)")]
        [Required(ErrorMessage = "Dato obligatorio")]
        public int Cilindrada { get; set; }
    }
}
