using Autofac;
using MartenBackend.Repository;
using System;
using System.Reflection;

namespace MartenBackend.Repository.DI
{
    public class RepositoryModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(CustomerRepository).GetTypeInfo().Assembly)
                 .Where(t => t.Name.EndsWith("Repository"))
                 .AsImplementedInterfaces();
        }
    }
}
