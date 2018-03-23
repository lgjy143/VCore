using System;
using System.Collections.Generic;
using System.Text;

namespace VCore.Dependency
{
    public static class IocRegistrarExtensions
    {
        /// <summary>
        /// Registers a type as self registration if it's not registered before.
        /// </summary>
        /// <param name="iocRegistrar">Registrar</param>
        /// <param name="type">Type of the class</param>
        /// <returns>True, if registered for given implementation.</returns>
        public static bool RegisterIfNot(this IIocRegistrar iocRegistrar, Type type)
        {
            if (iocRegistrar.IsRegistered(type))
            {
                return false;
            }

            iocRegistrar.Register(type);
            return true;
        }
    }
}
