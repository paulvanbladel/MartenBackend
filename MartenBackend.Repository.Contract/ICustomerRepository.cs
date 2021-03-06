using MartenBackend.Domain;
using MartenBackend.Common.Contract;
using System.Collections.Generic;

namespace MartenBackend.Repository.Contract
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void BulkInsert(Customer[] customers);
        void CompletelyRemove();
        IList<Customer> FindAllCustomersByFirstName(string firstName);
    }
}