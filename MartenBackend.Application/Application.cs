using System;
using System.Threading.Tasks;
using MartenBackend.Repository.Contract;
using MartenBackend.Domain;
using MartenBackend.BusinessEngine.Contract;
using MartenBackend.Common.Contract;
using System.Linq;

namespace MartenBackend.Application
{
    public class Applicationxxx : IApplication
    {
        private ISampleBusinessEngine _engine;
        private readonly ICustomerRepository _repo;

        public Applicationxxx(ICustomerRepository repo, ISampleBusinessEngine engine)
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

            //use direct repo
            var createdCustomer = await _repo.CreateAsync(customer);
            int id = createdCustomer.Id;
            var resultCustomer = await _repo.GetByIdAsync(id);
            Console.WriteLine($"Retrieved customer {customer.FirstName} {customer.LastName}");

            foreach (var c in await _repo.GetAsync())
            {
                Console.WriteLine($"Retrieved customer {c.FirstName} {c.LastName}");
                System.Console.WriteLine();
            }

            //use business Engine

            var amount = await _engine.ADataMiningOperation();

            Console.WriteLine("amount " + amount);



            Func<IQueryable<Customer>, IQueryable<Customer>> queryShaper
               = (shaper) => shaper.Where(d => d.FirstName == "jos").OrderBy(o => o.FirstName);

            var result =  _repo.GetAsync(queryShaper).Result;


        }
    }
}
