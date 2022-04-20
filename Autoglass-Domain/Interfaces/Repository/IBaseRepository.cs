using Autoglass_Domain_Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoglass_Domain.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task InsertAssync(TEntity obj);

        void Insert(TEntity obj);

        void Update(TEntity obj);

        //void Delete(int id);

        IList<TEntity> Select();
        Task<TEntity> Select(int id);
        Task SaveChangesAsync();
        IQueryable<TEntity> Query();
    }
}
