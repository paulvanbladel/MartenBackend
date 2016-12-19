using Autofac;
using MartenBackend.Application;

namespace MartenBackend.Bootstrapping.Consumer
{
    public class RepositoryIntegrationTests
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            string connectionString = AppConfig.GetConnectionStringBuildFromEnvironmentVariables();

            builder.RegisterModule(new RepositoryModule(connectionString));

            var container = builder.Build();
            return container;
        }
    }
}
