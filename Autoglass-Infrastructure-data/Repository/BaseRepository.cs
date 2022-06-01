using Autoglass_Domain.Interfaces.Repository;
using Autoglass_Domain_Core.Model;
using Autoglass_Infrastructure_data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoglass_Infrastructure_data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        protected readonly DataContext _dataContext;

        public DbSet<TEntity> DbSet { get; }

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            DbSet = _dataContext.Set<TEntity>();
        }
       

        public void Insert(TEntity obj)
        {
            _dataContext.Set<TEntity>().Add(obj);
            _dataContext.SaveChanges();
        }

        public virtual async Task<TEntity> Update(TEntity obj)
        {
            _dataContext.ChangeTracker.Clear();
            DbSet.Update(obj);
           await _dataContext.SaveChangesAsync();
            return obj;
        }

        public IList<TEntity> Select() =>
            _dataContext.Set<TEntity>().ToList();

        public async Task<TEntity> Select(int id) =>
          await _dataContext.Set<TEntity>().FindAsync(id);

        public async Task<TEntity> InsertAssync(TEntity obj)
        {
            await _dataContext.AddAsync(obj);
            await _dataContext.SaveChangesAsync();
            return obj;
        }
        

        public virtual IQueryable<TEntity> Query()
        {
            return DbSet;
        }
        public Task SaveChangesAsync()
        {
            return _dataContext.SaveChangesAsync();
        }
    }
}
