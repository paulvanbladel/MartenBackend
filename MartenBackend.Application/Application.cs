using System;
using System.Threading.Tasks;
using MartenBackend.Repository.Contract;
using MartenBackend.Domain;
using MartenBackend.BusinessEngine.Contract;

namespace MartenBackend.Application
{
       public class Application : IApplication
    {
        private ISampleBusinessEngine _engine;
        private readonly ICustomerRepository _repo;
        public Application(ICustomerRepository repo, ISampleBusinessEngine engine)
        {
            _repo = repo;
            _engine = engine;
        }

        public async Task RunAsync()
        {
            Customer customer = new Customer
            {
                FirstName = "paul",
                LastName = "van bladel"
            };
            var createdCustomer = await _repo.CreateAsync(customer);
            int id = createdCustomer.Id;
            var resultCustomer = await _repo.GetByIdAsync(id);
            Console.WriteLine($"Retrieved async customer {customer.FirstName} {customer.LastName}");
            
            foreach (var c in await _repo.GetAsync())
            {
            Console.WriteLine($"Retrieved customer {c.FirstName} {c.LastName}");
                System.Console.WriteLine();
            }

            //use business Engine

            var amount = _engine.ADataMiningOperation();

            Console.WriteLine("amount " + amount);



        }
    }
}
