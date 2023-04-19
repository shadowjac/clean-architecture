using System;
using Movies.Core.Entities.Base;

namespace Movies.Core.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}

