using MartenBackend.BusinessEngine.Contract;
using MartenBackend.Repository.Contract;
using System;
using System.Threading.Tasks;

namespace MartenBackend.BusinessEngine
{
    public class SampleBusinessEngine : ISampleBusinessEngine
    {
        private ICustomerRepository _repo;
        public SampleBusinessEngine(ICustomerRepository repo)
        {
            _repo = repo;
        }
        public async Task<double> ADataMiningOperation()
        {
            
            var result = await _repo.CountAsync();

            return Math.PI * result;
        }


    }
}
