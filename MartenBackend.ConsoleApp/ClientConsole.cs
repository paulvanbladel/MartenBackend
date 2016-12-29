using Autofac;
using Marten;
using MartenBackend.Application;
using MartenBackend.Application.DI;
using MartenBackend.BusinessEngine.DI;
using MartenBackend.Common;
using MartenBackend.Common.Contract;
using MartenBackend.Domain;
using MartenBackend.Repository.DI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartenBackend.ConsoleApp
{
    public class ClientConsole
    {
        public static IContainer GetContainer()
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

            builder.Register(r => Store).As<IDocumentStore>();

            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new BusinessEngineModule());
            builder.RegisterModule(new ApplicationModule());

            var container = builder.Build();
            return container;
        }
    }
}
