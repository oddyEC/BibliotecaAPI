using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Biblioteca.Domain;
namespace Curso.Biblioteca.Application
{
    public class LibroAppService : ILibroAppService
    {
        private readonly ILibroRepository repository;

        public LibroAppService(ILibroRepository repository)
        {
            this.repository = repository;
        }

        public Task<LibroDto> CreateAsync(LibroCrearActualizarDto libro)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int libroId)
        {
            throw new NotImplementedException();
        }

        public ICollection<LibroDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, LibroCrearActualizarDto libro)
        {
            throw new NotImplementedException();
        }
    }
}