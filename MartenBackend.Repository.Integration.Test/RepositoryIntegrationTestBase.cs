using Autofac;

using System;

namespace MartenBackend.Repository.Integration.Test
{
    public class RepositoryIntegrationTestBase : IDisposable
    {
        public IContainer Container;
        public RepositoryIntegrationTestBase()
        {
            Container = RepositoryIntegrationTests.GetContainer();
        }
        public void Dispose()
        {
            Container.Dispose();
        }
        protected TEntity Resolve<TEntity>()
        {
            return Container.Resolve<TEntity>();
        }
    }
}
