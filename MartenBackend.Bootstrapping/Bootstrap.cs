using Autofac;
using MartenBackend.Application;
using MartenBackend.Domain;
using MartenBackend.Repository;
using System.Reflection;

namespace MartenBackend.Bootstrapping
{
    public static class Bootstrap
    {
        public static IContainer GetContainerForConsoleApp()
        {
            var builder = new ContainerBuilder();
            string connectionString = AppConfig.GetConnectionStringBuildFromEnvironmentVariables();

            builder.RegisterModule(new CommonModule(connectionString));

            builder.RegisterType<Application.Application>().As<IApplication>();

            var container = builder.Build();
            return container;
        }

        public static IContainer GetContainerForBusinessEngineUnitTest()
        {
            var builder = new ContainerBuilder();
            string connectionString = "dummy";

            builder.RegisterType<ObjectContext>().SingleInstance().WithParameter("connectionString", connectionString);
            builder.RegisterAssemblyTypes(typeof(CustomerRepository).GetTypeInfo().Assembly)
                 .Where(t => t.Name.EndsWith("Repository"))
                 .AsImplementedInterfaces();
            //builder.RegisterModule(new CommonModule(connectionString));

            var container = builder.Build();
            return container;
        }


    }
}



