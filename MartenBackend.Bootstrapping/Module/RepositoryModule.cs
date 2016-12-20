
using Autofac;
using Marten;
using MartenBackend.Common;
using MartenBackend.Repository;
using System.Reflection;

namespace MartenBackend.Bootstrapping
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