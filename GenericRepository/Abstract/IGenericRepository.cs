using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepository.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> DataQueryable();
        IEnumerable<TEntity> DataEnumerable();
        Task<IEnumerable<TEntity>> SelectAllAsync();
        IEnumerable<TEntity> SelectAll();
        TEntity SelectByID(object id);
        void Insert4ID(TEntity obj, Func<TEntity, int> getter, Action<TEntity, int> setter);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(object id);
        void SaveChanges();
        Task<int> SaveChangesAsync();
        void Dispose();
    }
}
