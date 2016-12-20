using MartenBackend.Bootstrapping.Consumer;
using System;
using Xunit;
using Autofac;
using MartenBackend.Repository.Contract;
using MartenBackend.Domain;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MartenBackend.Bootstrapping;
using System.Linq;
using MartenBackend.Common;
using System.Collections.Generic;

namespace MartenBackend.Repository.Integration.Test
{
    public class CustomerRepositoryIntegrationTests : RepositoryIntegrationTestBase
    {
        [Fact]
        public void CreateNew()
        {
            ICustomerRepository repo =
            this.Container.Resolve<ICustomerRepository>();
            Customer customer = new Customer
            {
                FirstName = "jos",
                LastName = "josmans"
            };

            var result = repo.CreateAsync(customer).Result;
            Assert.NotNull(result.Id);
            Assert.Equal("jos", result.FirstName);
        }

        [Fact]
        public void GetById()
        {
            ICustomerRepository repo =
            this.Container.Resolve<ICustomerRepository>();
            Customer customer = new Customer
            {
                FirstName = "jos",
                LastName = "josmans"
            };
            var created = repo.CreateAsync(customer).Result;

            var id = created.Id;
            var result = repo.GetByIdAsync(id).Result;
            Assert.Equal(id, result.Id);
            Assert.Equal("jos", result.FirstName);
        }
        [Fact]
        public void GetAll()
        {
            ICustomerRepository repo =
            this.Container.Resolve<ICustomerRepository>();

            repo.DeleteAll();

            Customer customer1 = new Customer
            {
                FirstName = "jos",
                LastName = "josmans"
            };
            var created1 = repo.CreateAsync(customer1).Result;
            Customer customer2 = new Customer
            {
                FirstName = "benoit",
                LastName = "benoitmans"
            };
            var created2 = repo.CreateAsync(customer2).Result;

            var result = repo.GetAsync().Result;
            Assert.Equal(2, result.Count);
            Assert.Equal("jos", result[0].FirstName);
            Assert.Equal("benoit", result[1].FirstName);
        }
        [Fact]
        public void DeleteAll()
        {
            ICustomerRepository repo =
            this.Container.Resolve<ICustomerRepository>();

            repo.DeleteAll(); //we are using the method under test for test setup :(

            Customer customer1 = new Customer
            {
                FirstName = "jos",
                LastName = "josmans"
            };
            var created1 = repo.CreateAsync(customer1).Result;
            Customer customer2 = new Customer
            {
                FirstName = "benoit",
                LastName = "benoitmans"
            };
            var created2 = repo.CreateAsync(customer2).Result;

            var result = repo.GetAsync().Result;
            Assert.Equal(2, result.Count);

            //ACT
            repo.DeleteAll();

            //ASSERT
            result = repo.GetAsync().Result;
            Assert.Equal(0, result.Count);

        }

        [Fact]
        public void WhereClause()
        {
            ICustomerRepository repo =
            this.Container.Resolve<ICustomerRepository>();

            repo.DeleteAll();

            Customer customer1 = new Customer
            {
                FirstName = "jos",
                LastName = "josmans"
            };
            var created1 = repo.CreateAsync(customer1).Result;
            Customer customer2 = new Customer
            {
                FirstName = "benoit",
                LastName = "benoitmans"
            };
            var created2 = repo.CreateAsync(customer2).Result;

            Func<IQueryable<Customer>, IQueryable<Customer>> queryShaper
                = (shaper) => shaper.Where(d => d.FirstName == "jos").OrderBy(o => o.FirstName);

            var result = repo.GetAsync(queryShaper).Result;
            Assert.Equal(1, result.Count);
            Assert.Equal("jos", result[0].FirstName);
        }


        [Fact]
        public void BulkInsert()
        {

            List<Customer> customerList = new List<Customer>();

            for (int i = 0; i < 1000; i++)
            {
                Customer customer = new Customer
                {
                    FirstName = "jos",
                    LastName = Guid.NewGuid().ToString()
                };

                customerList.Add(customer);
            }

            Customer[] customers = customerList.ToArray<Customer>();

            ICustomerRepository repo =
                this.Container.Resolve<ICustomerRepository>();

            repo.BulkInsert(customers);



        }

        [Fact]
        public void CompletelyRemove()
        {
            ICustomerRepository repo =
                this.Container.Resolve<ICustomerRepository>();
            repo.CompletelyRemove();
        }

        [Fact]
        public void CompileQuery()
        {
            ICustomerRepository repo =
                this.Container.Resolve<ICustomerRepository>();
            var result = repo.FindAllCustomersByFirstName("jos");

        }
    }
}
