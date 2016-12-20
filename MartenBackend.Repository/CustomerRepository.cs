using MartenBackend.Repository.Contract;
using MartenBackend.Domain;
using MartenBackend.Common;
using System.Collections.Generic;
using Marten;
using System.Threading.Tasks;
using System.Linq;
using Marten.Services.BatchQuerying;

namespace MartenBackend.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ObjectContext objectcontext) : base(objectcontext) { }

        public void BulkInsert(Customer[] customers)
        {
            this._objectContext.Store.BulkInsert(customers);
        }

        public void CompletelyRemove()
        {
            this._objectContext.Store.Advanced.Clean.CompletelyRemove(typeof(Customer));
        }

        public IList<Customer> FindAllCustomersByFirstName(string firstName)
        {
            using (var session = _objectContext.Store.QuerySession())
            {
                var query = new FindAllCustomersByFirstNameCompiledQuery(firstName);
                //TODO tolistasync is not working here
                return session.Query(query).ToList(); //.ToListAsync();
            }
        }


        //TODO investigate batched queries
        public void BatchQuery()
        {
            
                using (IQuerySession session = _objectContext.Store.QuerySession())
            {
                IBatchedQuery batch = session.CreateBatchQuery();
                var query = new FindAllCustomersByFirstNameCompiledQuery("abc");
                var result = batch.Query(query);

                batch.ExecuteSynchronously();
            }
        }
    }
}
