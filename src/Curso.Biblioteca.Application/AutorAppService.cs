
using Curso.Biblioteca.Domain;

namespace Curso.Biblioteca.Application
{
    public class AutorAppService : IAutorAppService
    {
        private readonly IAutorRepository repository;

        public AutorAppService(IAutorRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AutorDto> CreateAsync(AutorCrearActualizarDto autorDto)
        {
                       //Reglas Validaciones... 
            var existeNombreAutor = await repository.ExisteNombre(autorDto.Nombre);
            if (existeNombreAutor)
            {
                throw new ArgumentException($"Ya existe una autor con el nombre {autorDto.Nombre}");
            }

            //Mapeo Dto => Entidad
            var autor = new Autor();
            autor.Nombre = autorDto.Nombre;

            //Persistencia objeto
            autor = await repository.AddAsync(autor);
            //await unitOfWork.SaveChangesAsync();

            //Mapeo Entidad => Dto
            var autorCreado = new AutorDto();
            autorCreado.Nombre = autor.Nombre;
            autorCreado.Id = autor.Id;

            //TODO: Enviar un correo electronica... 

            return autorCreado;
        }

        public async Task<bool> DeleteAsync(int autorId)
        {
            var autor = await repository.GetByIdAsync(autorId);
            if (autor == null)
            {
                throw new ArgumentException($"El autor con el id: {autorId}, no existe");
            }
            repository.Delete(autor);
            return true;
        }

        public ICollection<AutorDto> GetAll()
        {
            var autorList = repository.GetAll();
            var autorListDto = from e in autorList
                                   select new AutorDto()
                                   {
                                       Id = e.Id,
                                       Nombre = e.Nombre
                                   };
            return autorListDto.ToList();
        }

        public async Task UpdateAsync(int id, AutorCrearActualizarDto autorDto)
        {
            var autor = await repository.GetByIdAsync(id);
            if (autor == null)
            {
                throw new ArgumentException($"La autor con el id: {id}, no existe");
            }
            var existeNombreAutor = await repository.ExisteNombre(autorDto.Nombre, id);
            if (existeNombreAutor)
            {
                throw new ArgumentException($"Ya existe una autor con el nombre {autorDto.Nombre}");
            }
            //mapeo Dto => Entidad
            autor.Nombre = autorDto.Nombre;
            await repository.UpdateAsync(autor);

            return;
        }


    }
}