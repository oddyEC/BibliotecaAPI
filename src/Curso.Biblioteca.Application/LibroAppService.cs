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
       // private readonly IUnitOfWork unitOfWork;

        public LibroAppService(ILibroRepository repository)
        {
            this.repository = repository;
            //this.unitOfWork = unitOfWork;
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
            libro.AutorId = libroDto.AutorId;
            libro.EditorialId = libroDto.EditorialId;

            //Persistencia objeto
            libro = await repository.AddAsync(libro);
            //await unitOfWork.SaveChangesAsync();

            //Mapeo Entidad => Dto
            var libroCreado = new LibroDto();
            libroCreado.Nombre = libro.Nombre;
            libroCreado.Id = libro.Id;
            libroCreado.AutorId = libro.AutorId;
            libroCreado.EditorialId = libro.EditorialId;

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

        public ListaPaginada<LibroDto> GetAll(int limit = 10, int offset = 0)
        {
            
            var libroList = repository.GetAllIncluding(x => x.Autor,
                                                        x => x.Editorial);
            var total = libroList.Count();
            // var libroListDto = from e in libroList
            //                        select new LibroDto()
            //                        {
            //                            Id = e.Id,
            //                            Nombre = e.Nombre
            //                        };
            var libroListDto = libroList.Skip(offset)
                                        .Take(limit)
                                        .Select(
                                            x => new LibroDto()
                                            {
                                                Id = x.Id,
                                                Nombre = x.Nombre,
                                                AutorId = x.Autor.Id,
                                                Autor = x.Autor.Nombre,
                                                Editorial = x.Editorial.Nombre

                                            }
                                        );
            var resultado = new ListaPaginada<LibroDto>();
            resultado.Total = total;
            resultado.Lista = libroListDto.ToList();
            return resultado;
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
            libro.AutorId = libroDto.AutorId;
            libro.EditorialId = libroDto.EditorialId;
            await repository.UpdateAsync(libro);
            //await repository.UnitOfWork.SaveChangesAsync();

            return;
        }
    }
}