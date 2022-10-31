using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Application
{
    public interface ILibroAppService
    {
        ICollection<LibroDto> GetAll();

        Task<LibroDto> CreateAsync(LibroCrearActualizarDto libro);

        Task UpdateAsync(int id, LibroCrearActualizarDto libro);

        Task<bool> DeleteAsync(int libroId);
    }
}