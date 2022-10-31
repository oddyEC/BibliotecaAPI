using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Domain
{
    public interface IEditorialRepository : IRepository<Editorial>
    {
        Task<bool> ExisteNombre(string nombre);

        Task<bool> ExisteNombre(string nombre, int idExcluir);
    }
}