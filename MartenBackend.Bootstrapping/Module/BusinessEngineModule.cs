using Autofac;
using MartenBackend.BusinessEngine;
using System.Reflection;

namespace MartenBackend.Bootstrapping
{
    public class BusinessEngineModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(SampleBusinessEngine).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("BusinessEngine"))
                .AsImplementedInterfaces();
        }
    }
}
