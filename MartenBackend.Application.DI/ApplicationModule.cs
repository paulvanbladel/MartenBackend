using System;
using Autofac;
using MartenBackend.Common.Contract;
using MartenBackend.Application;
namespace MartenBackend.Application.DI
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<Application.Applicationxxx>().As<IApplication>();
        }
    }
}
