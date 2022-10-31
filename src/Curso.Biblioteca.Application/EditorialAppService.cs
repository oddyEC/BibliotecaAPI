using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Biblioteca.Domain;

namespace Curso.Biblioteca.Application
{
    public class EditorialAppService : IEditorialAppService
    {
        private readonly IEditorialRepository repository;

        public EditorialAppService(IEditorialRepository repository)
        {
            this.repository = repository;
        }
        public async Task<EditorialDto> CreateAsync(EditorialCrearActualizarDto editorialDto)
        {
            //Reglas Validaciones... 
            var existeNombreEditorial = await repository.ExisteNombre(editorialDto.Nombre);
            if (existeNombreEditorial)
            {
                throw new ArgumentException($"Ya existe una editorial con el nombre {editorialDto.Nombre}");
            }

            //Mapeo Dto => Entidad
            var editorial = new Editorial();
            editorial.Nombre = editorialDto.Nombre;

            //Persistencia objeto
            editorial = await repository.AddAsync(editorial);
            //await unitOfWork.SaveChangesAsync();

            //Mapeo Entidad => Dto
            var editorialCreada = new EditorialDto();
            editorialCreada.Nombre = editorial.Nombre;
            editorialCreada.Id = editorial.Id;

            //TODO: Enviar un correo electronica... 

            return editorialCreada;
        }

        public async Task<bool> DeleteAsync(int editorialId)
        {
            var editorial = await repository.GetByIdAsync(editorialId);
            if (editorial == null)
            {
                throw new ArgumentException($"La editorial con el id: {editorialId}, no existe");
            }
            repository.Delete(editorial);
            return true;
        }

        public ICollection<EditorialDto> GetAll()
        {
            var editorialList = repository.GetAll();
            var editorialListDto = from e in editorialList
                                      select new EditorialDto()
                                      {
                                          Id = e.Id,
                                          Nombre = e.Nombre
                                      };
            return editorialListDto.ToList();
        }

        public async Task UpdateAsync(int id, EditorialCrearActualizarDto editorialDto)
        {
            var editorial = await repository.GetByIdAsync(id);
            if (editorial == null)
            {
                throw new ArgumentException($"La editorial con el id: {id}, no existe");
            }
            var existeNombreEditorial = await repository.ExisteNombre(editorialDto.Nombre, id);
            if (existeNombreEditorial)
            {
                throw new ArgumentException($"Ya existe una editorial con el nombre {editorialDto.Nombre}");
            }
            //mapeo Dto => Entidad
            editorial.Nombre = editorialDto.Nombre;
            await repository.UpdateAsync(editorial);

            return;
        }
    }
}