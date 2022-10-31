using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Curso.Biblioteca.Domain;

namespace Curso.Biblioteca.Application
{
    public class AutorDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
        public string Nombre { get; set; }
    }
}