using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore5.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es requerido")]
        [StringLength(50, ErrorMessage ="El {0} debe ser almenos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Título")]
        public String Titulo { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(200, ErrorMessage = "El {0} debe ser almenos {2} y máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Descripción")]
        public String Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }

        [Required(ErrorMessage = "El autor es requerido")]
        public String Autor { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        public double Precio { get; set; }
    }
}
