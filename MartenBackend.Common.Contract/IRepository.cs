using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartenBackend.Common.Contract
{
    public interface IRepository { }

    public interface IRepository<T> : IRepository
        where T : class, new()
    {
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T customer);
        Task<int> CountAsync();
        Task<IList<T>> GetAsync();
        Task<IList<T>> GetAsync(Func<IQueryable<T>, IQueryable<T>> queryShaper);
        Task Delete(T entity);
        Task Delete(int id);
        Task DeleteAll();
    }
}
