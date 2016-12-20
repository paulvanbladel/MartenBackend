using Marten.Linq;
using MartenBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MartenBackend.Repository
{
    public class FindAllCustomersByFirstNameCompiledQuery : ICompiledListQuery<Customer>
    {
        public string FirstName { get; set; }
        public FindAllCustomersByFirstNameCompiledQuery(string firstName)
        {
            FirstName = firstName;
        }
        public Expression<Func<IQueryable<Customer>, IEnumerable<Customer>>> QueryIs()
        {
            return query => query.Where(x => x.FirstName == FirstName);
        }
    }
}
