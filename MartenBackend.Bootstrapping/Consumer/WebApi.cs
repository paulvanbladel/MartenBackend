using Autofac;
using Marten;
using MartenBackend.Common;
using MartenBackend.Domain;
using Microsoft.Extensions.DependencyInjection;
namespace MartenBackend.Bootstrapping.Consumer
{
    public class WebApi
    {
        public static IContainer GetContainer(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            string connectionString = @"host=localhost;database=postgres;password=.;username=postgres";

            var Store = DocumentStore.For(configure =>
            {
                configure.Connection(connectionString);
                configure.Schema.For<Customer>().UseOptimisticConcurrency(true).SoftDeleted();
                //using pre-supplied logger
                //configure.Logger(new ConsoleMartenLogger());
                configure.Logger(new CustomMartenLogger());
                //TODO integrate with serilog

            });


            // for web api we use InstancePerRequest
            builder.Register(r => Store).As<IDocumentStore>().InstancePerRequest();

            builder.RegisterModule(new RepositoryModule());
            

            var container = builder.Build();
            return container;
        }
    }
}
