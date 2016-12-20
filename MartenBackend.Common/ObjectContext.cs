using Marten;
using MartenBackend.Domain;

namespace MartenBackend.Common
{
    public class ObjectContext
    {
        public ObjectContext(string connectionString)
        {
            Store = DocumentStore.For(configure =>
           {
               configure.Connection(connectionString);
               configure.Schema.For<Customer>().UseOptimisticConcurrency(true).SoftDeleted();
               //using pre-supplied logger
               //configure.Logger(new ConsoleMartenLogger());
               configure.Logger(new CustomMartenLogger());
               //TODO integrate with serilog
               
           });
        }
        public IDocumentStore Store { get; private set; }
    }
}