using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MimoBackendChallenge.DAL.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(TEntity entity);
        Task SaveAsync();
    }
}
