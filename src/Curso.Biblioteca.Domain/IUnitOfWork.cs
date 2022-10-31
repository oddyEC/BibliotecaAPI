using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Domain
{
    public interface IUnitOfWork: IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}