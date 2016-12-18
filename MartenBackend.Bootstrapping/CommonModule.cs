
using Autofac;
using MartenBackend.BusinessEngine;
using MartenBackend.Repository;
using System.Reflection;

namespace MartenBackend.Bootstrapping
{
    public class CommonModule : Autofac.Module
    {
        private string _connectionString;
        public CommonModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ObjectContext>().SingleInstance().WithParameter("connectionString", _connectionString);
            builder.RegisterAssemblyTypes(typeof(CustomerRepository).GetTypeInfo().Assembly)
                 .Where(t => t.Name.EndsWith("Repository"))
                 .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(SampleBusinessEngine).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("BusinessEngine"))
                .AsImplementedInterfaces();
        }
    }
}