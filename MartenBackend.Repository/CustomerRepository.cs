using MartenBackend.Repository.Contract;
using MartenBackend.Domain;
using MartenBackend.Common;
using System.Collections.Generic;
using Marten;
using System.Linq;
using Marten.Services.BatchQuerying;

namespace MartenBackend.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDocumentStore documentStore) : base(documentStore) { }

        public void BulkInsert(Customer[] customers)
        {
            this._documentStore.BulkInsert(customers);
        }

        public void CompletelyRemove()
        {
            this._documentStore.Advanced.Clean.CompletelyRemove(typeof(Customer));
        }

        public IList<Customer> FindAllCustomersByFirstName(string firstName)
        {
            using (var session = _documentStore.QuerySession())
            {
                var query = new FindAllCustomersByFirstNameCompiledQuery(firstName);
                //TODO tolistasync is not working here
                return session.Query(query).ToList(); //.ToListAsync();
            }
        }


        //TODO investigate batched queries
        public void BatchQuery()
        {
            
                using (var session = _documentStore.QuerySession())
            {
                IBatchedQuery batch = session.CreateBatchQuery();
                var query = new FindAllCustomersByFirstNameCompiledQuery("abc");
                var result = batch.Query(query);

                batch.ExecuteSynchronously();
            }
        }
    }
}
