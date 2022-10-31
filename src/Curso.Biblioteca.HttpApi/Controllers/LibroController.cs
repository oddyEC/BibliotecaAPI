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
    public class LibroController : ControllerBase
    {
        private readonly ILibroAppService libroAppService;

        public LibroController(ILibroAppService libroAppService)
        {
            this.libroAppService = libroAppService;
        }
        [HttpGet]
        public ICollection<LibroDto> GetAll()
        {

            return libroAppService.GetAll();
        }

        [HttpPost]
        public async Task<LibroDto> CreateAsync(LibroCrearActualizarDto libroDto)
        {

            return await libroAppService.CreateAsync(libroDto);

        }

        [HttpPut]
        public async Task UpdateAsync(int id, LibroCrearActualizarDto libroDto)
        {

            await libroAppService.UpdateAsync(id, libroDto);

        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int libroId)
        {

            return await libroAppService.DeleteAsync(libroId);

        }
    }
}