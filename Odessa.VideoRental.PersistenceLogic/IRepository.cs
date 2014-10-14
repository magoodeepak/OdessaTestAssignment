using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odessa.VideoRental.PersistenceLogic
{
    public interface IRepository<TEntity>
    {
        #region CRUD operations

        TEntity Save(TEntity instance);
        void Update(TEntity instance);
        void Remove(TEntity instance);

        #endregion

        #region Retrieval Operations

        TEntity GetById(long id);
        IQueryable<TEntity> FindAll();

        #endregion
    }

    public abstract class RepositoryEntityStore<TEntity>
        : IRepository<TEntity>
    {
        protected static IDictionary<long, TEntity> RepositoryMap = new Dictionary<long, TEntity>();

        #region IRepository<TEntity> Members

        public abstract TEntity Save(TEntity instance);

        public abstract void Update(TEntity instance);

        public abstract void Remove(TEntity instance);

        public TEntity GetById(long id)
        {
            return RepositoryMap[id];
        }

        public IQueryable<TEntity> FindAll()
        {
            return RepositoryMap.Values.AsQueryable();
        }

        #endregion
    }
}
