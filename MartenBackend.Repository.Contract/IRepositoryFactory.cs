using System;
using System.Collections.Generic;
using System.Text;

namespace MartenBackend.Repository.Contract
{
    // you could use a factory, but not recommended, because needs in the end service locator
    public interface IRepositoryFactory
    {
        T GetRepository<T>() where T : IRepository;
    }
}
