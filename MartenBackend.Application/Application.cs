using System;
using System.Threading.Tasks;
using MartenBackend.Repository.Contract;
using MartenBackend.Domain;

namespace MartenBackend.Application
{
       public class Application : IApplication
    {
        private readonly ICustomerRepository _repo;
        public Application(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public async Task Run()
        {
            Customer customer = new Customer
            {
                FirstName = "paul",
                LastName = "van bladel"
            };
            var createdCustomer = await _repo.Create(customer);
            int id = createdCustomer.Id;
            var resultCustomer = await _repo.GetById(id);
            Console.WriteLine($"Retrieved async customer {customer.FirstName} {customer.LastName}");
            var amount = await _repo.Count();
            Console.WriteLine("amount " + amount);

            foreach (var c in await _repo.Get())
            {
            Console.WriteLine($"Retrieved customer {c.FirstName} {c.LastName}");
                System.Console.WriteLine();
            }
        }
    }
}
