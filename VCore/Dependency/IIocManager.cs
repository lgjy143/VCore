using System;
using VCore.Dependency.IocContainers;

namespace VCore.Dependency
{
    public interface IIocManager : IIocResolver, IIocRegistrar, IDisposable
    {
        /// <summary>
        /// Reference to the Container.
        /// </summary>
       IIocContainer IocContainer { get; }
    }
}
