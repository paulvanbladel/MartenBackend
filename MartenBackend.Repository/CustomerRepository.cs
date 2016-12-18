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

        public async Task<IList<Customer>> Get()
        {
            using (var session = _objectContext.GetStore().QuerySession())
            {
                //CancellationToken token = new CancellationToken();
                
                return await session.Query<Customer>().ToListAsync() ;
            }
        }
        public async Task<Customer> GetById(int id)
        {
            using (var session = _objectContext.GetStore().QuerySession())
            {
                return await session.LoadAsync<Customer>(id);
            }
        }
        public async Task<Customer> Create(Customer customer)
        {
            using (var session = _objectContext.GetStore().LightweightSession())
            {
                session.Store(customer);
                await session.SaveChangesAsync();
                return customer;
            }
        }

        public async Task<int> Count()
        {
            using (var session = _objectContext.GetStore().QuerySession())
            {
                CancellationToken token = new CancellationToken();
                return await session.Query<Customer>().CountAsync(token);
            }
        }
    }
}