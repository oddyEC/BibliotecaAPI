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
    public class AutorController : ControllerBase
    {
        private readonly IAutorAppService autorAppService;

        public AutorController(IAutorAppService autorAppService)
        {
            this.autorAppService = autorAppService;
        }
        [HttpGet]
        public ICollection<AutorDto> GetAll()
        {

            return autorAppService.GetAll();
        }

        [HttpPost]
        public async Task<AutorDto> CreateAsync(AutorCrearActualizarDto autorDto)
        {

            return await autorAppService.CreateAsync(autorDto);

        }

        [HttpPut]
        public async Task UpdateAsync(int id, AutorCrearActualizarDto autorDto)
        {

            await autorAppService.UpdateAsync(id, autorDto);

        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int autorId)
        {

            return await autorAppService.DeleteAsync(autorId);

        }
    }
}