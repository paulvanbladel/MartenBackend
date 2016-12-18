using System.Collections.Generic;
using System.Threading.Tasks;
using MartenBackend.Domain;
namespace MartenBackend.Repository.Contract
{
    public interface ICustomerRepository: IRepository
    {
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> CreateAsync(Customer customer);
        Task<int> CountAsync();
        Task<IList<Customer>> GetAsync();

    }

    


    
    
}