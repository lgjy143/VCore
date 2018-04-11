using System;
using System.Collections.Generic;
using System.Text;
using VCore.Dependency.IocContainer;

namespace VCore.Dependency
{
    public class IocManager : IIocManager
    {
        public static IocManager Instance { get; private set; }

        public IIocContainer IocContainer { get; private set; }

        static IocManager()
        {
            Instance = new IocManager();
        }

        public void Register(Type type)
        {
            IocContainer.Register(type);
        }

        public bool IsRegistered(Type type)
        {
            return IocContainer.IsRegistered(type);
        }

        public bool IsRegistered<TType>()
        {
            return IocContainer.IsRegistered<TType>();
        }

        public object Resolve(Type type)
        {
            return IocContainer.Resolve(type);
        }
    }
}
