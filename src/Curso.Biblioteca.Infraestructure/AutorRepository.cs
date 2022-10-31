using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;

namespace Curso.Biblioteca.Infraestructure
{
    public class AutorRepository : EfRepository<Autor>
    {
        public AutorRepository(BibliotecaDbContext context) : base(context)
        {
        }
    }
}