using System.Threading.Tasks;

namespace MartenBackend.BusinessEngine.Contract
{
    public interface ISampleBusinessEngine
    {
        Task<double> ADataMiningOperation();
    }
}
