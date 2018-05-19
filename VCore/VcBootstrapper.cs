using Autofac;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using VCore.Configuration.Startup;
using VCore.Dependency;
using VCore.Dependency.Installers;
using VCore.Modules;
using VCore.PlugIns;

namespace VCore
{
    public class VcBootstrapper : IDisposable
    {
        private ILogger _logger;

        private VcModuleManager _moduleManager;

        protected bool IsDisposed;

        private VcBootstrapper([NotNull] Type startupModule)
           : this(startupModule, Dependency.IocManager.Instance)
        {
        }

        private VcBootstrapper([NotNull] Type startupModule, [NotNull] IIocManager iocManager)
        {
            Check.NotNull(startupModule, nameof(startupModule));
            Check.NotNull(iocManager, nameof(iocManager));

            if (!typeof(VcModule).IsAssignableFrom(startupModule))
            {
                throw new ArgumentException($"{nameof(startupModule)} should be derived from {nameof(VcModule)}.");
            }

            StartupModule = startupModule;
            IocManager = iocManager;
            Dependency.IocManager.Instance.ReplaceInstance((IocManager)iocManager);

            PlugInSources = new PlugInSourceList();
            _logger = NullLogger.Instance;
        }
        public Type StartupModule { get; }

        public PlugInSourceList PlugInSources { get; }

        public IIocManager IocManager { get; }
        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }
            IsDisposed = true;
            _moduleManager?.ShutdownModules();
        }

        public static VcBootstrapper Create<TStartupModule>()
           where TStartupModule : VcModule
        {
            return new VcBootstrapper(typeof(TStartupModule));
        }

        public static VcBootstrapper Create<TStartupModule>([NotNull] IIocManager iocManager)
            where TStartupModule : VcModule
        {
            return new VcBootstrapper(typeof(TStartupModule), iocManager);
        }

        public static VcBootstrapper Create([NotNull] Type startupModule)
        {
            return new VcBootstrapper(startupModule);
        }

        public static VcBootstrapper Create([NotNull] Type startupModule, [NotNull] IIocManager iocManager)
        {
            return new VcBootstrapper(startupModule, iocManager);
        }

        public virtual void Initialize()
        {
            ResolveLogger();

            try
            {
                RegisterBootstrapper();
                IocManager.IocContainer.Install(new VcCoreInstaller());

                IocManager.Resolve<VcPlugInManager>().PlugInSources.AddRange(PlugInSources);
                IocManager.Resolve<VcStartupConfiguration>().Initialize();

                _moduleManager = IocManager.Resolve<VcModuleManager>();
                _moduleManager.Initialize(StartupModule);
                _moduleManager.StartModules();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.ToString(), ex);
                throw;
            }
        }

        private void ResolveLogger()
        {
            if (IocManager.IsRegistered<ILoggerFactory>())
            {
                _logger = IocManager.Resolve<ILoggerFactory>().CreateLogger(typeof(VcBootstrapper));
            }
        }

        private void RegisterBootstrapper()
        {
            if (!IocManager.IsRegistered<VcBootstrapper>())
            {
                IocManager.IocContainer.Register(builder => builder.RegisterInstance(this));
            }
        }
    }
}
