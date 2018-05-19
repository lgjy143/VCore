using System;
using Autofac;

namespace VCore.Dependency.IocContainers
{
    public interface IIocContainer : IDisposable
    {
        IContainer Kernel { get; }
        void Install(params IIocInstaller[] installers);
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

        void Register(Type type);

        void Register(Action<ContainerBuilder> registrationBuilder);
        /// <summary>
        /// Gets an object from IOC container.
        /// Returning object must be Released (see <see cref="Release"/>) after usage.
        /// </summary> 
        /// <param name="type">Type of the object to get</param>
        /// <returns>The object instance</returns>
        object Resolve(Type type);
        TService Resolve<TService>();
        TService[] ResolveAll<TService>();
    }
}
