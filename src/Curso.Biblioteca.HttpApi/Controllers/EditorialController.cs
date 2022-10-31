using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Curso.Biblioteca.Application;


namespace Curso.Biblioteca.HttpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialAppService editorialAppService;

        public EditorialController(IEditorialAppService editorialAppService)
        {
            this.editorialAppService = editorialAppService;
        }
        [HttpGet]
        public ICollection<EditorialDto> GetAll()
        {

            return editorialAppService.GetAll();
        }

        [HttpPost]
        public async Task<EditorialDto> CreateAsync(EditorialCrearActualizarDto editorialDto)
        {

            return await editorialAppService.CreateAsync(editorialDto);

        }

        [HttpPut]
        public async Task UpdateAsync(int id, EditorialCrearActualizarDto editorialDto)
        {

            await editorialAppService.UpdateAsync(id, editorialDto);

        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int editorialId)
        {

            return await editorialAppService.DeleteAsync(editorialId);

        }

    }
}