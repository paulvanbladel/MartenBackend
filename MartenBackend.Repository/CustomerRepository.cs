using MartenBackend.Repository.Contract;
using MartenBackend.Domain;
using MartenBackend.Common;

namespace MartenBackend.Repository
{
   

    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ObjectContext objectcontext) : base(objectcontext) { }
    }
}