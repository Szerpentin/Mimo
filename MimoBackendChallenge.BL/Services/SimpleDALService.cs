using AutoMapper;
using MimoBackendChallenge.BL.IServices;
using MimoBackendChallenge.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimoBackendChallenge.BL.Services
{
    public class SimpleDALService<TModel, TEntity> : ISimpleDALService<TModel, TEntity> where TModel : class, new() where TEntity : class
    {
        private IRepository<TEntity> repository { get; set; }
        private readonly IMapper mapper;
        public SimpleDALService(IRepository<TEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<TModel>> GetAllAsync()
        {
            return (await repository.GetAllAsync()).Select(s => mapper.Map<TModel>(s)).ToList();
        }

        public async Task<TModel> GetByIdAsync(int id)
        {
            return mapper.Map<TModel>((await repository.GetByIdAsync(id)));
        }

        public async Task<TModel> CreateAsync(TModel model)
        {
           // The repository may modify - but should not - the entity, thats the reason why we map it back 
           return mapper.Map<TModel>(await repository.CreateAsync(mapper.Map<TEntity>(model)));
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
