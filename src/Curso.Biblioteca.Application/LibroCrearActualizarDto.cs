using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Curso.Biblioteca.Domain;

namespace Curso.Biblioteca.Application
{
    public class LibroCrearActualizarDto
    {
        [Required]
        [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
        public string Nombre { get; set; }
        [Required]
        public int AutorId { get; set; }
        [Required]
        public int EditorialId { get; set; }
    }
}