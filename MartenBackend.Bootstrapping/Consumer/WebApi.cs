using Autofac;
using Microsoft.Extensions.DependencyInjection;
namespace MartenBackend.Bootstrapping.Consumer
{
    public class WebApi
    {
        public static IContainer GetContainer(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            //builder.RegisterModule(new CommonModule());
            //builder.Populate(services);
            var container = builder.Build();
            return container;
        }
    }
}
