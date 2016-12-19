using Autofac;
using MartenBackend.Bootstrapping.Consumer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartenBackend.Bootstrapping
{
    public class IocSupportedTest
    {
        public IContainer container;
        public IocSupportedTest()
        {
            container = BusinessEngineUnitTests.GetContainer();

        }
        public void InjectMock<TInjectable>(object mockObject)
        {
            var newBuilder = new ContainerBuilder();
            newBuilder.RegisterInstance(mockObject).As<TInjectable>();
            newBuilder.Update(this.container);
        }
        protected TEntity Resolve<TEntity>()
        {
            return container.Resolve<TEntity>();
        }

        protected void ShutdownIoC()
        {
            container.Dispose();
        }
    }
}
