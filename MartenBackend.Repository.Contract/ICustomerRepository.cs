using System.Collections.Generic;
using System.Threading.Tasks;
using MartenBackend.Domain;
using System.Linq.Expressions;
using System;
using System.Linq;
using MartenBackend.Common;
using MartenBackend.Common.Contract;

namespace MartenBackend.Repository.Contract
{
    public interface ICustomerRepository : IRepository<Customer>
    {
       //add specific customer repo method...
    }
}