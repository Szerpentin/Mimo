using Microsoft.EntityFrameworkCore;
using MimoBackendChallenge.DAL.IRepositories;
using MimoBackendChallenge.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MimoBackendChallenge.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly MimoContext _context;
        DbSet<TEntity> entityDbSet;
        public Repository(MimoContext context)
        {
            _context = context;
            entityDbSet = _context.Set<TEntity>();
        }

        public async virtual Task<List<TEntity>> GetAllAsync()
        {
            return await entityDbSet.ToListAsync();
        }
        public async virtual Task<TEntity> GetByIdAsync(int id)
        {
            return await entityDbSet.FindAsync(id);
        }
        public async virtual Task<TEntity> CreateAsync(TEntity entity)
        {
            await entityDbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async virtual Task DeleteAsync(int id)
        {
            TEntity entity = await GetByIdAsync(id);
            entityDbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async virtual Task DeleteAsync(TEntity entity)
        {
            entityDbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async virtual Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
