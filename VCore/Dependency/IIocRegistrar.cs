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
        void Register<TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
           where TImpl : class;

        void Register(Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);
        /// <summary>
        /// Registers a type with it's implementation.
        /// </summary>
        /// <typeparam name="TType">Registering type</typeparam>
        /// <typeparam name="TImpl">The type that implements <see cref="TType"/></typeparam>
        /// <param name="lifeStyle">Lifestyle of the objects of this type</param>
        void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType;
        void Register(Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);
    }
}
