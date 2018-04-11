using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using VCore.Dependency.IocContainer;

namespace VCore.Dependency
{
    public interface IIocManager : IIocResolver, IIocRegistrar
    {
        /// <summary>
        /// Reference to the Container.
        /// </summary>
        IIocContainer IocContainer { get; }

        ///// <summary>
        ///// Checks whether given type is registered before.
        ///// </summary>
        ///// <param name="type">Type to check</param>
        //bool IsRegistered(Type type);

        ///// <summary>
        ///// Checks whether given type is registered before.
        ///// </summary>
        ///// <typeparam name="T">Type to check</typeparam>
        //bool IsRegistered<T>();
    }
}
