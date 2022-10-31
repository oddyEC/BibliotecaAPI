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

        public async Task<LibroDto> CreateAsync(LibroCrearActualizarDto libroDto)
        {
            var existeNombreLibro = await repository.ExisteNombre(libroDto.Nombre);
            if (existeNombreLibro)
            {
                throw new ArgumentException($"Ya existe un libro con el nombre {libroDto.Nombre}");
            }

            //Mapeo Dto => Entidad
            var libro = new Libro();
            libro.Nombre = libroDto.Nombre;

            //Persistencia objeto
            libro = await repository.AddAsync(libro);
            //await unitOfWork.SaveChangesAsync();

            //Mapeo Entidad => Dto
            var libroCreado = new LibroDto();
            libroCreado.Nombre = libro.Nombre;
            libroCreado.Id = libro.Id;

            //TODO: Enviar un correo electronica... 

            return libroCreado;
        }

        public async Task<bool> DeleteAsync(int libroId)
        {
            var libro = await repository.GetByIdAsync(libroId);
            if (libro == null)
            {
                throw new ArgumentException($"La libro con el id: {libroId}, no existe");
            }
            repository.Delete(libro);
            return true;
        }

        public ICollection<LibroDto> GetAll()
        {
            var libroList = repository.GetAll();
            var libroListDto = from e in libroList
                                   select new LibroDto()
                                   {
                                       Id = e.Id,
                                       Nombre = e.Nombre
                                   };
            return libroListDto.ToList();
        }

        public async Task UpdateAsync(int id, LibroCrearActualizarDto libroDto)
        {
            var libro = await repository.GetByIdAsync(id);
            if (libro == null)
            {
                throw new ArgumentException($"La libro con el id: {id}, no existe");
            }
            var existeNombreLibro = await repository.ExisteNombre(libroDto.Nombre, id);
            if (existeNombreLibro)
            {
                throw new ArgumentException($"Ya existe una libro con el nombre {libroDto.Nombre}");
            }
            //mapeo Dto => Entidad
            libro.Nombre = libroDto.Nombre;
            await repository.UpdateAsync(libro);

            return;
        }
    }
}