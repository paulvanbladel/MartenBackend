using System.Collections.Generic;
using System.Threading.Tasks;
using MartenBackend.Domain;
namespace MartenBackend.Repository.Contract
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(int id);
        Task<Customer> Create(Customer customer);
        Task<int> Count();
        Task<IList<Customer>> Get();

    }
}