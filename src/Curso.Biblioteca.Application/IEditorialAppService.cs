using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Application
{
    public interface IEditorialAppService
    {
        ICollection<EditorialDto> GetAll();

        Task<EditorialDto> CreateAsync(EditorialCrearActualizarDto editorial);

        Task UpdateAsync(int id, EditorialCrearActualizarDto editorial);

        Task<bool> DeleteAsync(int editorialId);
    }
}