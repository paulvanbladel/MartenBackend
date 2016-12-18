using MartenBackend.BusinessEngine.Contract;
using MartenBackend.Repository.Contract;
using System;

namespace MartenBackend.BusinessEngine
{
    public class SampleBusinessEngine : ISampleBusinessEngine
    {
        private ICustomerRepository _repo;
        public SampleBusinessEngine(ICustomerRepository repo)
        {
            _repo = repo;
        }
        
        public double ADataMiningOperation()
        {
            
            //TODO async
            var result = _repo.CountAsync().Result;

            return Math.PI * result;
        }


    }
}
