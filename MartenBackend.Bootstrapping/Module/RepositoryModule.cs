
using Autofac;
using MartenBackend.Common;
using MartenBackend.Repository;
using System.Reflection;

namespace MartenBackend.Bootstrapping
{
    public class RepositoryModule : Autofac.Module
    {
        private string _connectionString;
        public RepositoryModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ObjectContext>().SingleInstance().WithParameter("connectionString", _connectionString);

            builder.RegisterAssemblyTypes(typeof(CustomerRepository).GetTypeInfo().Assembly)
                 .Where(t => t.Name.EndsWith("Repository"))
                 .AsImplementedInterfaces();
        }
    }
}