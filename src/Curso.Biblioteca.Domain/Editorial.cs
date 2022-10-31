using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Curso.Biblioteca.Domain
{
    public class Editorial
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
        public string Nombre { get; set; }
    }
}