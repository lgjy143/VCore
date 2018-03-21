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

        //public bool IsRegistered(Type type)
        //{
        //    return IocContainer.Contains(type);
        //}

        //public bool IsRegistered<T>()
        //{
        //    return IocContainer.Kernel.HasComponent(typeof(TType));
        //}

        public object Resolve(Type type)
        {
            return IocContainer.BuildServiceProvider().GetService(type);
        }
    }
}
