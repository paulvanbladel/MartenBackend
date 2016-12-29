using System;
using Autofac;
using System.Reflection;

namespace MartenBackend.BusinessEngine.DI
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
