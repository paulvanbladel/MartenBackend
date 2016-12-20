using Autofac;
using Marten;
using MartenBackend.Application;
using MartenBackend.Common;
using MartenBackend.Common.Contract;
using MartenBackend.Domain;

namespace MartenBackend.Bootstrapping.Consumer
{
    public class ClientConsole
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            string connectionString = AppConfig.GetConnectionStringBuildFromEnvironmentVariables();

            var Store = DocumentStore.For(configure =>
            {
                configure.Connection(connectionString);
                configure.Schema.For<Customer>().UseOptimisticConcurrency(true).SoftDeleted();
                //using pre-supplied logger
                //configure.Logger(new ConsoleMartenLogger());
                configure.Logger(new CustomMartenLogger());
                //TODO integrate with serilog

            });

            builder.Register(r => Store).As<IDocumentStore>();

            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new BusinessEngineModule());
            builder.RegisterType<Application.Application>().As<IApplication>();

            var container = builder.Build();
            return container;
        }
    }
}
