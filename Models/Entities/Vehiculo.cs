using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Index = System.Index;

namespace Models.Entities
{
    [Table("Vehiculo")]
    [Index(nameof(Patente), IsUnique = true)]
    public abstract class Vehiculo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Dato obligatorio")]
        public string Patente { get; set; }
        [Required(ErrorMessage = "Dato obligatorio")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Dato obligatorio")]
        public string Modelo { get; set; }
        public virtual ICollection<Desperfecto> Desperfectos { get; set; }
    }
}
