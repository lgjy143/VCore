using System;
using System.Collections.Generic;
using System.Text;

namespace VCore.Dependency.IocContainer
{
    public class IocContainer : IIocContainer
    {
        /// <summary>Represents the current object container.
        /// </summary>
        public static IIocContainer Instance { get; private set; }

        /// <summary>Set the object container.
        /// </summary>
        /// <param name="container"></param>
        public static void SetContainer(IIocContainer container)
        {
            Instance = container;
        }

        public bool IsRegistered(Type type)
        {
            return Instance.IsRegistered(type);
        }

        public bool IsRegistered<TType>()
        {
            return Instance.IsRegistered<TType>();
        }

        public void Register(Type type)
        {
            Instance.Register(type);
        }

        public object Resolve(Type type)
        {
            return Instance.Resolve(type);
        }
    }
}
