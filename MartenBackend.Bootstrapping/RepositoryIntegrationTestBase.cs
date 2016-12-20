﻿using Autofac;
using MartenBackend.Bootstrapping.Consumer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartenBackend.Bootstrapping
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