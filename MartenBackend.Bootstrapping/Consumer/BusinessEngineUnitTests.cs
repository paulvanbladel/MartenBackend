using Autofac;

namespace MartenBackend.Bootstrapping.Consumer
{
    public class BusinessEngineUnitTests
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
 
            //var Store = DocumentStore.For("");

            //builder.Register(r => Store).As<IDocumentStore>();



            builder.RegisterModule(new RepositoryModule());

            var container = builder.Build();
            return container;
        }
    }
}
