using Autofac;
using MartenBackend.Application;
using MartenBackend.Common.Contract;

namespace MartenBackend.Bootstrapping.Consumer
{
    public class ClientConsole
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            string connectionString = AppConfig.GetConnectionStringBuildFromEnvironmentVariables();

            builder.RegisterModule(new RepositoryModule(connectionString));
            builder.RegisterModule(new BusinessEngineModule());
            builder.RegisterType<Application.Application>().As<IApplication>();

            var container = builder.Build();
            return container;
        }
    }
}
