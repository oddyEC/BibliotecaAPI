using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Domain
{
    public interface IAutorRepository : IRepository<Autor>
    {
        Task<bool> ExisteNombre(string nombre);

        Task<bool> ExisteNombre(string nombre, int idExcluir);
    }
}