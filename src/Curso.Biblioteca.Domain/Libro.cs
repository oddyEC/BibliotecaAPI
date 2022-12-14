using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curso.Biblioteca.Domain
{
    public class Libro
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
        public string Nombre { get; set; }
        [Required]
        public int AutorId { get; set; }
        public virtual Autor Autor { get; set; }
        [Required]
        public int EditorialId { get; set; }
        public virtual Editorial Editorial { get; set; }

    }
}