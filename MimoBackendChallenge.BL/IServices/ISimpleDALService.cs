using System.Collections.Generic;
using System.Threading.Tasks;

namespace MimoBackendChallenge.BL.IServices
{
    public interface ISimpleDALService<TModel, TEntity> where TModel : class, new() where TEntity : class
    {
        Task<List<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(int id);
        Task<TModel> CreateAsync(TModel model);
        Task DeleteAsync(int id);
    }
}
