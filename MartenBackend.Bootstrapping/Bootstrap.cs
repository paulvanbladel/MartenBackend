using Autofac;
using MartenBackend.Application;
using MartenBackend.Domain;
using System;

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
         static Bootstrap()
        {

        }
    }
}



