using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Marten;
using MartenBackend.Repository.Contract;
using MartenBackend.Domain;
namespace MartenBackend.Repository
{
    public  class CustomerRepository : ICustomerRepository
    {
        private ObjectContext _objectContext;
        public CustomerRepository(ObjectContext objectcontext)
        {
            _objectContext = objectcontext;
        }
        public async Task<IList<Customer>> GetAsync()
        {
            using (var session = _objectContext.GetStore().QuerySession())
            {
                //CancellationToken token = new CancellationToken();
                
                return await session.Query<Customer>().ToListAsync() ;
            }
        }
        public async Task<Customer> GetByIdAsync(int id)
        {
            using (var session = _objectContext.GetStore().QuerySession())
            {
                return await session.LoadAsync<Customer>(id);
            }
        }
        public async Task<Customer> CreateAsync(Customer customer)
        {
            using (var session = _objectContext.GetStore().LightweightSession())
            {
                session.Store(customer);
                await session.SaveChangesAsync();
                return customer;
            }
        }
        public async Task<int> CountAsync()
        {
            using (var session = _objectContext.GetStore().QuerySession())
            {
                CancellationToken token = new CancellationToken();
                return await session.Query<Customer>().CountAsync(token);
            }
        }
    }
}