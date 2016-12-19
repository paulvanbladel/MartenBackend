using Autofac;

namespace MartenBackend.Bootstrapping.Consumer
{
    public class BusinessEngineUnitTests
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            string connectionString = "dummy";
            builder.RegisterModule(new RepositoryModule(connectionString));

            var container = builder.Build();
            return container;
        }
    }
}
