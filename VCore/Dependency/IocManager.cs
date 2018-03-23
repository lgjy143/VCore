using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace VCore.Dependency
{
    public class IocManager : IIocManager
    {
        public static IocManager Instance { get; private set; }

        public IServiceCollection IocContainer { get; private set; }

        static IocManager()
        {
            Instance = new IocManager();
        }

        public void Register(Type type)
        {
            IocContainer.AddSingleton(type);
        }

        public bool IsRegistered(Type type)
        {
            return IocContainer.BuildServiceProvider().GetService(type) != null;
        }

        public bool IsRegistered<TType>()
        {
            return IocContainer.BuildServiceProvider().GetService<TType>() != null;
        }

        public object Resolve(Type type)
        {
            return IocContainer.BuildServiceProvider().GetService(type);
        }
    }
}
