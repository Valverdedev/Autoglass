using Autoglass_Domain_Core.Model;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoglass_Domain.Interfaces.Service
{
  
        public interface IBaseService<TEntity> where TEntity : Entity
        {
        Task Adicionar(TEntity entity);

        void Update(TEntity entity);       

        Task Remove(TEntity entity);      

        IEnumerable<TEntity> GetAll();

        Task<TEntity> Get(int id);
    }
   
}
