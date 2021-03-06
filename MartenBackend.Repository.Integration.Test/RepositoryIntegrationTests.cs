﻿using Autofac;
using Marten;
using MartenBackend.Common;
using MartenBackend.Domain;
using MartenBackend.Repository.DI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartenBackend.Repository.Integration.Test
{
    public class RepositoryIntegrationTests
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            //TODO temp solution because env vars are not read from test lib project


            //string connectionString = AppConfig.GetConnectionStringBuildFromEnvironmentVariables();
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

            var container = builder.Build();
            return container;
        }
    }
}
