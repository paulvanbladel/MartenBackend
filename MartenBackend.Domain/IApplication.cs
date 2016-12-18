using System.Threading.Tasks;

namespace MartenBackend.Domain
{
    public interface IApplication
    {
        Task RunAsync();
    }
}
