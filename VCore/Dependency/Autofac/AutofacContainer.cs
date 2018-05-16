using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using VCore.Dependency.IocContainer;

namespace VCore.Dependency.Autofac
{
    public class AutofacContainer 
    {
        private readonly ContainerBuilder _containerBuilder;
        private IContainer _container;

        public AutofacContainer() : this(new ContainerBuilder())
        {
        }

        public AutofacContainer(ContainerBuilder containerBuilder)
        {
            _containerBuilder = containerBuilder;
        }

        public void Build()
        {
            _container = _containerBuilder.Build();
        }

        public bool IsRegistered(Type type)
        {
            return _container.IsRegistered(type);
        }

        public bool IsRegistered<TType>()
        {
            return _container.IsRegistered<TType>();
        }

        public void Register(Type type)
        {
            _containerBuilder.RegisterType(type);
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}
