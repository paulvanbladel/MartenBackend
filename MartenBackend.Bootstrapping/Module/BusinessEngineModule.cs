using Autofac;
using MartenBackend.BusinessEngine;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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
