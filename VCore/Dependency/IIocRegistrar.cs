using System;
using System.Collections.Generic;
using System.Text;

namespace VCore.Dependency
{
    public interface IIocRegistrar
    {
        void Register(Type type);
        /// <summary>
        /// Checks whether given type is registered before.
        /// </summary>
        /// <param name="type">Type to check</param>
        bool IsRegistered(Type type);

        /// <summary>
        /// Checks whether given type is registered before.
        /// </summary>
        /// <typeparam name="TType">Type to check</typeparam>
        bool IsRegistered<TType>();
    }
}
