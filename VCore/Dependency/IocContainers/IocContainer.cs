using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VCore.Dependency.IocContainers
{
    public class IocContainer : IIocContainer
    {
        public IContainer Kernel { get; }
        public ContainerBuilder Builder => new ContainerBuilder();

        public IocContainer()
        {
            Kernel = Builder.Build();
        }

        public void Dispose()
        {
            Kernel.Dispose();
        }
        public bool IsRegistered(Type type)
        {
            return Kernel.IsRegistered(type);
        }
        public bool IsRegistered<TType>()
        {
            return Kernel.IsRegistered<TType>();
        }
        public void Register(Action<ContainerBuilder> registrationBuilder)
        {
            var builder = new ContainerBuilder();
            registrationBuilder(builder);
            builder.Update(Kernel);
        }

        public void Register(Type type)
        {
            Builder.RegisterType(type);
        }
        public object Resolve(Type type)
        {
            return Kernel.Resolve(type);
        }

        public TService Resolve<TService>()
        {
            return Kernel.Resolve<TService>();
        }

        public TService[] ResolveAll<TService>()
        {
            return Kernel.Resolve<IEnumerable<TService>>().ToArray();
        }
    }
}
