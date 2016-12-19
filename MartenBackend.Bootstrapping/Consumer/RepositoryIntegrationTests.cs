using Autofac;
using MartenBackend.Application;

namespace MartenBackend.Bootstrapping.Consumer
{
    public class RepositoryIntegrationTests
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            //TODO temp solution because env vars are not read from test lib project


            //string connectionString = AppConfig.GetConnectionStringBuildFromEnvironmentVariables();
            string connectionString = @"host=localhost;database=postgres;password=.;username=postgres";
            builder.RegisterModule(new RepositoryModule(connectionString));

            var container = builder.Build();
            return container;
        }
    }
}
