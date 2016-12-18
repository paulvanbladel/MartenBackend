// using System;
// using System.Linq;

// using Xunit;

// namespace MartenBackend.Repository.Test
// {
//     public class SmokeUnitTest
//     {
//         public DocumentStore Store { get; set; }

//         public SmokeUnitTest()
//         {
//             var connectionString = AppConfig.GetConnectionStringBuildFromEnvironmentVariables();

//             Store = new ObjectContext(connectionString).GetStore();
//         }

//         [Fact]
//         public void CreateCustomerAndRetrieveThatCustomerBasedOnIdShouldBeTheSame()
//         {
//             int id;


//                 Customer customer = new Customer
//                 {
//                     FirstName = "paul",
//                     LastName = "van bladel"
//                 };
               
            
//             using (var session = Store.QuerySession())
//             {
//                 var customer = session.Load<Customer>(id);
//                 Assert.Equal(expected: "van bladel", actual: customer?.LastName);
//             }
//         }

//         [Fact]
//         public void CreateCustomerAndRetrieveThatCustomerBasedOnQueryOnLastNameShouldBeTheSame()
//         {
//             string guid = Guid.NewGuid().ToString();
//             using (Store)
//             using (var session = Store.LightweightSession())
//             {

//                 Customer customer = new Customer
//                 {
//                     FirstName = "paul",
//                     LastName = guid
//                 };
//                 session.Store(customer);
//                 session.SaveChanges();
//             }

//             using (var session = Store.QuerySession())
//             {
//                 var customer = session.Query<Customer>().SingleOrDefault(c => c.LastName == guid);
//                 Assert.Equal(expected: guid, actual: customer?.LastName);
//             }
//         }
//     }
// }
