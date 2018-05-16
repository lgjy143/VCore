using Autofac;
using System;

namespace VCore.Dependency.IocContainer
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

        public object Resolve(Type type)
        {
            return Kernel.Resolve(type);
        }

        public void Register(Type type)
        {
            Builder.RegisterType(type);
        }
    }
}
