using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marten;
using System.Linq;
using System.Threading;
using MartenBackend.Common.Contract;

namespace MartenBackend.Common
{
    public abstract class RepositoryBase<T> : IRepository<T>
          where T : class, new()
    {
        private ObjectContext _objectContext;

        public RepositoryBase(ObjectContext objectcontext)
        {
            _objectContext = objectcontext;
        }
        public async Task<IList<T>> GetAsync()
        {
            using (var session = _objectContext.GetStore().QuerySession())
            {
                //CancellationToken token = new CancellationToken();

                return await session.Query<T>().ToListAsync();
            }
        }
        public async Task<T> GetByIdAsync(int id)
        {
            using (var session = _objectContext.GetStore().QuerySession())
            {
                return await session.LoadAsync<T>(id);
            }
        }
        public async Task<T> CreateAsync(T entity)
        {
            using (var session = _objectContext.GetStore().LightweightSession())
            {
                session.Store(entity);
                await session.SaveChangesAsync();
                return entity;
            }
        }
        public async Task<IList<T>> GetAsync(Func<IQueryable<T>, IQueryable<T>> queryShaper)
        {
            using (var session = _objectContext.GetStore().QuerySession())
            {
                return await queryShaper(session.Query<T>()).ToListAsync();
            }
        }
        public virtual async Task<int> CountAsync()
        {
            using (var session = _objectContext.GetStore().QuerySession())
            {
                //TODO cancellation token
                CancellationToken token = new CancellationToken();
                return await session.Query<T>().CountAsync(token);
            }
        }
        public async Task Delete(T entity)
        {
            using (var session = _objectContext.GetStore().LightweightSession())
            {
                session.Delete<T>(entity);
                await session.SaveChangesAsync();
                return;
            }
        }
        public async Task Delete(int id)
        {
            using (var session = _objectContext.GetStore().LightweightSession())
            {
                session.Delete<T>(id);
                await session.SaveChangesAsync();
                return;
            }
        }
        public async Task DeleteAll()
        {
            using (var session = _objectContext.GetStore().LightweightSession())
            {
                session.DeleteWhere<T>((c) => true);
                await session.SaveChangesAsync();
                return;
            }
        }
    }
}
