using Autofac;
using Castle.DynamicProxy;
using VCore.Dependency.IocContainers;

namespace VCore.Dependency
{
    public class BasicConventionalRegistrar : IConventionalDependencyRegistrar
    {
        public void RegisterAssembly(IConventionalRegistrationContext context)
        {
            context.IocManager.IocContainer.Register(builder =>
            {
                //Transient
                builder.RegisterAssemblyTypes(context.Assembly)
                    .AssignableTo<ITransientDependency>()
                    .AsSelf()
                    .AsImplementedInterfaces()
                    .PropertiesAutowired()
                    .LifestyleTransient();

                //Singleton
                builder.RegisterAssemblyTypes(context.Assembly)
                    .AssignableTo<ISingletonDependency>()
                    .AsSelf()
                    .AsImplementedInterfaces()
                    .PropertiesAutowired()
                    .LifestyleSingleton();

                //Interceptors
                builder.RegisterAssemblyTypes(context.Assembly)
                    .AssignableTo<IInterceptor>()
                    .AsSelf()
                    .AsImplementedInterfaces()
                    .PropertiesAutowired()
                    .LifestyleTransient();
            });
        }
    }
}
