using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using JetBrains.Annotations;
using VCore.Dependency.IocContainers;
using VCore.Reflection;

namespace VCore.Dependency
{
    public class IocManager : IIocManager
    {
        private readonly List<IConventionalDependencyRegistrar> _conventionalRegistrars;

        public static IocManager Instance { get; private set; }

        public IIocContainer IocContainer { get; private set; }

        static IocManager()
        {
            Instance = new IocManager();
        }
        public IocManager()
        {
            IocContainer = new IocContainer();
            _conventionalRegistrars = new List<IConventionalDependencyRegistrar>();

            IocContainer.Register(builder =>
                    builder.RegisterInstance(this)
                        .AsSelf()
                        .As<IIocManager>()
                        .As<IIocRegistrar>()
                        .As<IIocResolver>()
            );
        }

        public void AddConventionalRegistrar(IConventionalDependencyRegistrar registrar)
        {
            _conventionalRegistrars.Add(registrar);
        }
        public void RegisterAssemblyByConvention(Assembly assembly)
        {
            RegisterAssemblyByConvention(assembly, new ConventionalRegistrationConfig());
        }

        /// <summary>
        /// Registers types of given assembly by all conventional registrars. See <see cref="AddConventionalRegistrar"/> method.
        /// </summary>
        /// <param name="assembly">Assembly to register</param>
        /// <param name="config">Additional configuration</param>
        public void RegisterAssemblyByConvention(Assembly assembly, ConventionalRegistrationConfig config)
        {
            var context = new ConventionalRegistrationContext(assembly, this, config);

            foreach (var registerer in _conventionalRegistrars)
            {
                registerer.RegisterAssembly(context);
            }
            if (config.InstallInstallers && IsRegistered<ITypeFinder>())
            {
                var typeFinder = Resolve<ITypeFinder>();
                var installers = typeFinder.FindClassesOfType<IIocInstaller>(assembly);
                foreach (var installer in installers)
                {
                    IocContainer.Install((IIocInstaller)Activator.CreateInstance(installer));
                }
            }
        }

        public bool IsRegistered(Type type)
        {
            return IocContainer.IsRegistered(type);
        }

        public bool IsRegistered<TType>()
        {
            return IocContainer.IsRegistered<TType>();
        }
       
        public void Register<TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TImpl : class
        {
            IocContainer.Register(builder =>
            {
                if (typeof(TImpl).GetTypeInfo().IsGenericType)
                {
                    builder.RegisterGeneric(typeof(TImpl))
                        .PropertiesAutowired()
                        .ApplyLifestyle(lifeStyle);
                }
                else
                {
                    builder.RegisterType<TImpl>()
                        .PropertiesAutowired()
                        .ApplyLifestyle(lifeStyle);
                }
            });
        }

        public void Register(Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            IocContainer.Register(builder =>
            {
                if (impl.GetTypeInfo().IsGenericType)
                {
                    builder.RegisterGeneric(impl)
                        .PropertiesAutowired()
                        .ApplyLifestyle(lifeStyle);
                }
                else
                {
                    builder.RegisterType(impl)
                        .PropertiesAutowired()
                        .ApplyLifestyle(lifeStyle);
                }
            });
        }
        public void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
             where TType : class
             where TImpl : class, TType
        {
            IocContainer.Register(builder =>
            {
                if (typeof(TImpl).GetTypeInfo().IsGenericType)
                {
                    builder.RegisterGeneric(typeof(TImpl))
                        .AsSelf()
                        .As<TType>()
                        .PropertiesAutowired()
                        .ApplyLifestyle(lifeStyle);
                }
                else
                {
                    builder.RegisterType<TImpl>()
                        .AsSelf()
                        .As<TType>()
                        .PropertiesAutowired()
                        .ApplyLifestyle(lifeStyle);
                }
            });
        }
        public void Register(Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            IocContainer.Register(builder =>
            {
                if (impl.GetTypeInfo().IsGenericType)
                {
                    builder.RegisterGeneric(impl)
                        .AsSelf()
                        .As(type)
                        .PropertiesAutowired()
                        .ApplyLifestyle(lifeStyle);
                }
                else
                {
                    builder.RegisterType(impl)
                        .AsSelf()
                        .As(type)
                        .PropertiesAutowired()
                        .ApplyLifestyle(lifeStyle);
                }
            });
        }

        public object Resolve(Type type)
        {
            return IocContainer.Resolve(type);
        }
        public T Resolve<T>(Type type)
        {
            return (T)IocContainer.Resolve(type);
        }
        public T Resolve<T>()
        {
            return IocContainer.Resolve<T>();
        }

        public T[] ResolveAll<T>()
        {
            return IocContainer.ResolveAll<T>();
        }

        public void Dispose()
        {
            IocContainer.Dispose();
        }

        internal void ReplaceInstance([NotNull] IocManager instance)
        {
            Check.NotNull(instance, nameof(instance));
            Instance = instance;
        }
    }
}
