
using Curso.Biblioteca.Domain;

namespace Curso.Biblioteca.Application
{
    public class AutorAppService: IAutorAppService
    {
        private readonly IAutorRepository repository;

        public AutorAppService(IAutorRepository repository)
        {
            this.repository = repository;
        }

        public Task<AutorDto> CreateAsync(AutorCrearActualizarDto autor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int autorId)
        {
            throw new NotImplementedException();
        }

        public ICollection<AutorDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, AutorCrearActualizarDto autor)
        {
            throw new NotImplementedException();
        }


    }
}