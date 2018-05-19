using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using VCore.Configuration.Startup;
using VCore.Dependency.IocContainers;
using VCore.Modules;
using VCore.PlugIns;
using VCore.Reflection;

namespace VCore.Dependency.Installers
{
    public class VcCoreInstaller : IIocInstaller
    {
        public void Install(IIocContainer container)
        {
            //TODO: Fix
            container.Register(builder =>
            {
                //builder.RegisterType<IUnitOfWorkDefaultOptions, UnitOfWorkDefaultOptions>().AsSelf().LifestyleSingleton();
                //builder.RegisterType<INavigationConfiguration, NavigationConfiguration>().ImplementedBy<NavigationConfiguration>().LifestyleSingleton();
                //builder.RegisterType<ILocalizationConfiguration, LocalizationConfiguration>().ImplementedBy<LocalizationConfiguration>().LifestyleSingleton();
                //builder.RegisterType<IAuthorizationConfiguration, AuthorizationConfiguration>().ImplementedBy<AuthorizationConfiguration>().LifestyleSingleton();
                //builder.RegisterType<IValidationConfiguration, ValidationConfiguration>().ImplementedBy<ValidationConfiguration>().LifestyleSingleton();
                //builder.RegisterType<IFeatureConfiguration, FeatureConfiguration>().ImplementedBy<FeatureConfiguration>().LifestyleSingleton();
                //builder.RegisterType<ISettingsConfiguration, SettingsConfiguration>().ImplementedBy<SettingsConfiguration>().LifestyleSingleton();
                builder.RegisterType<ModuleConfiguration>().As<IModuleConfiguration>().AsSelf().LifestyleSingleton();
                //builder.RegisterType<IEventBusConfiguration, EventBusConfiguration>().ImplementedBy<EventBusConfiguration>().LifestyleSingleton();
                //builder.RegisterType<IMultiTenancyConfig, MultiTenancyConfig>().ImplementedBy<MultiTenancyConfig>().LifestyleSingleton();
                //builder.RegisterType<ICachingConfiguration, CachingConfiguration>().ImplementedBy<CachingConfiguration>().LifestyleSingleton();
                //builder.RegisterType<IAuditingConfiguration, AuditingConfiguration>().ImplementedBy<AuditingConfiguration>().LifestyleSingleton();
                //builder.RegisterType<IBackgroundJobConfiguration, BackgroundJobConfiguration>().ImplementedBy<BackgroundJobConfiguration>().LifestyleSingleton();
                //builder.RegisterType<INotificationConfiguration, NotificationConfiguration>().ImplementedBy<NotificationConfiguration>().LifestyleSingleton();
                //builder.RegisterType<IEmbeddedResourcesConfiguration, EmbeddedResourcesConfiguration>().ImplementedBy<EmbeddedResourcesConfiguration>().LifestyleSingleton();
                builder.RegisterType<VcStartupConfiguration>().As<IVcStartupConfiguration>().AsSelf().LifestyleSingleton();
                //builder.RegisterType<IEntityHistoryConfiguration, EntityHistoryConfiguration>().ImplementedBy<EntityHistoryConfiguration>().LifestyleSingleton();
                builder.RegisterType<TypeFinder>().As<ITypeFinder>().AsSelf().LifestyleSingleton().PropertiesAutowired();
                builder.RegisterType<VcPlugInManager>().As<IVcPlugInManager>().AsSelf().LifestyleSingleton();
                builder.RegisterType<VcModuleManager>().As<IVcModuleManager>().AsSelf().LifestyleSingleton().PropertiesAutowired();
                builder.RegisterType<VcAssemblyFinder>().As<IAssemblyFinder>().AsSelf().LifestyleSingleton();
                //builder.RegisterType<ILocalizationManager, LocalizationManager>().ImplementedBy<LocalizationManager>().LifestyleSingleton();
            });
        }
    }
}
