using Autofac;
using Autofac.Builder;
using System.Linq;
using System.Reflection;

namespace VCore.Dependency.IocContainers
{
    public static class RegistrationExtensions
    {
        public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> ApplyLifestyle<TLimit, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> registration, DependencyLifeStyle lifeStyle)
        {
            switch (lifeStyle)
            {
                case DependencyLifeStyle.Transient:
                    return registration.LifestyleTransient();
                case DependencyLifeStyle.Singleton:
                    return registration.LifestyleSingleton();
                default:
                    return registration;
            }
        }
        public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> LifestyleSingleton<TLimit, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> registration)
        {
            return registration.SingleInstance();
        }

        public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> LifestyleTransient<TLimit, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> registration)
        {
            return registration.InstancePerDependency();
        }

        public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> PropertiesAutowired<TLimit, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> registration)
        {
            if (typeof(TLimit).GetTypeInfo().GetCustomAttributes<UninjectPropertiesAttribute>().Any())
            {
                return registration;
            }
            return registration.PropertiesAutowired(PropertyWiringOptions.None);
        }
    }
}
