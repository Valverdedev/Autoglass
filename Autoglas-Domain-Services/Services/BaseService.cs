using Autoglass_Domain.Interfaces.Repository;
using Autoglass_Domain.Interfaces.Service;
using Autoglass_Domain_Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoglas_Domain_Services.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Entity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task Adicionar(TEntity entity)
        {
           await _baseRepository.InsertAssync(entity);
        }

        public async Task<TEntity> Get(int id)
        {
           return await _baseRepository.Select(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _baseRepository.Select();
        }

        public Task Remove(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(TEntity entity)
        {
           _baseRepository.Update(entity);
        }
    }
}
