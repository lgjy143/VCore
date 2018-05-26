using Autofac;
using VCore.Configuration.Startup;
using VCore.Dependency;
using VCore.Modules;
using VCore.Reflection;

namespace VCore
{
    public class VcKernelModule : VcModule
    {
        public override void PreInitialize()
        {
            IocManager.AddConventionalRegistrar(new BasicConventionalRegistrar());

            //IocManager.Register<IScopedIocResolver, ScopedIocResolver>(DependencyLifeStyle.Transient);
            //IocManager.Register(typeof(IAmbientScopeProvider<>), typeof(DataContextAmbientScopeProvider<>), DependencyLifeStyle.Transient);

            //AddAuditingSelectors();
            //AddLocalizationSources();
            //AddSettingProviders();
            //AddUnitOfWorkFilters();
            //ConfigureCaches();
            //AddIgnoredTypes();
            //AddMethodParameterValidators();
        }

        public override void Initialize()
        {
            foreach (var replaceAction in ((VcStartupConfiguration)Configuration).ServiceReplaceActions.Values)
            {
                replaceAction();
            }

            //IocManager.IocContainer.Install(new EventBusInstaller(IocManager));

            IocManager.RegisterAssemblyByConvention(InternalAssembly.GetExecutingAssembly(),
                new ConventionalRegistrationConfig
                {
                    InstallInstallers = false
                });
        }

        public override void PostInitialize()
        {
            RegisterMissingComponents();

            //IocManager.Resolve<SettingDefinitionManager>().Initialize();
            //IocManager.Resolve<FeatureManager>().Initialize();
            //IocManager.Resolve<PermissionManager>().Initialize();
            //IocManager.Resolve<LocalizationManager>().Initialize();
            //IocManager.Resolve<NotificationDefinitionManager>().Initialize();
            //IocManager.Resolve<NavigationManager>().Initialize();

            //if (Configuration.BackgroundJobs.IsJobExecutionEnabled)
            //{
            //    var workerManager = IocManager.Resolve<IBackgroundWorkerManager>();
            //    workerManager.Start();
            //    workerManager.Add(IocManager.Resolve<IBackgroundJobManager>());
            //}
        }

        public override void Shutdown()
        {
            //if (Configuration.BackgroundJobs.IsJobExecutionEnabled)
            //{
            //    IocManager.Resolve<IBackgroundWorkerManager>().StopAndWaitToStop();
            //}
        }
        private void RegisterMissingComponents()
        {
            if (!IocManager.IsRegistered<IGuidGenerator>())
            {
                IocManager.IocContainer.Register(builder =>
                        builder.RegisterInstance(SequentialGuidGenerator.Instance)
                            .AsSelf()
                            .As<IGuidGenerator>()
                );
            }

            //if (!IocManager.IsRegistered<ICurrentUnitOfWorkProvider>())
            //{
            //    IocManager.IocContainer.Register(builder =>
            //            builder.RegisterType<CallContextCurrentUnitOfWorkProvider>()
            //                .AsSelf()
            //                .As<ICurrentUnitOfWorkProvider>()
            //                .WithProperty(TypedParameter.From(Logger))
            //                .LifestyleTransient()
            //    );
            //}

            //IocManager.RegisterIfNot<IUnitOfWork, NullUnitOfWork>(DependencyLifeStyle.Transient);
            //IocManager.RegisterIfNot<IAuditingStore, SimpleLogAuditingStore>(DependencyLifeStyle.Singleton);
            //IocManager.RegisterIfNot<IPermissionChecker, NullPermissionChecker>(DependencyLifeStyle.Singleton);
            //IocManager.RegisterIfNot<IRealTimeNotifier, NullRealTimeNotifier>(DependencyLifeStyle.Singleton);
            //IocManager.RegisterIfNot<INotificationStore, NullNotificationStore>(DependencyLifeStyle.Singleton);
            //IocManager.RegisterIfNot<IUnitOfWorkFilterExecuter, NullUnitOfWorkFilterExecuter>(DependencyLifeStyle.Singleton);
            //IocManager.RegisterIfNot<IClientInfoProvider, NullClientInfoProvider>(DependencyLifeStyle.Singleton);
            //IocManager.RegisterIfNot<ITenantStore, NullTenantStore>(DependencyLifeStyle.Singleton);
            //IocManager.RegisterIfNot<ITenantResolverCache, NullTenantResolverCache>(DependencyLifeStyle.Singleton);
            //IocManager.RegisterIfNot<IEntityHistoryStore, NullEntityHistoryStore>(DependencyLifeStyle.Singleton);

            //if (Configuration.BackgroundJobs.IsJobExecutionEnabled)
            //{
            //    IocManager.RegisterIfNot<IBackgroundJobStore, InMemoryBackgroundJobStore>(DependencyLifeStyle.Singleton);
            //}
            //else
            //{
            //    IocManager.RegisterIfNot<IBackgroundJobStore, NullBackgroundJobStore>(DependencyLifeStyle.Singleton);
            //}
        }
    }
}
