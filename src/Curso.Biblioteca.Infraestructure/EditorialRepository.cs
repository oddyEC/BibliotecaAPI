using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Biblioteca.Domain;
namespace Curso.Biblioteca.Infraestructure;
using Microsoft.EntityFrameworkCore;

public class EditorialRepository : EfRepository<Editorial>, IEditorialRepository
{
    public EditorialRepository(BibliotecaDbContext context) : base(context)
    {
    }

    public async Task<bool> ExisteNombre(string nombre)
    {
        var resultado = await this._context.Set<Editorial>()
           .AnyAsync(x => x.Nombre.ToUpper() == nombre.ToUpper());

        return resultado;
    }

    public async Task<bool> ExisteNombre(string nombre, int idExcluir)
    {
        var query = this._context.Set<Editorial>()
           .Where(x => x.Id != idExcluir)
           .Where(x => x.Nombre.ToUpper() == nombre.ToUpper())
           ;

        var resultado = await query.AnyAsync();

        return resultado;
    }
}
