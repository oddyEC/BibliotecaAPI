using System.Runtime.InteropServices.ComTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Curso.Biblioteca.Domain
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll(bool asNoTracking = true);

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        void Delete(TEntity entity);

        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
    }
}