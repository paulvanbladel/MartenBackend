using MartenBackend.Repository.Contract;
using MartenBackend.Domain;
using MartenBackend.Common;

namespace MartenBackend.Repository
{
    //public static class IRepoExtensions
    //{
    //    public static Task<IList<T>> GetAsyncxxx<T>(
    //        this ICustomerRepository repo, 
    //        Func<IQueryable<T>,  IQueryable<T>> queryShaper) where T:class
    //    {
    //        return repo.GetAsync2(queryShaper);
    //    }

    //}

    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ObjectContext objectcontext) : base(objectcontext) { }
    }
}