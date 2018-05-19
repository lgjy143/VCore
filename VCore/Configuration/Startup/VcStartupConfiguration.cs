using System;
using System.Collections.Generic;
using System.Text;
using VCore.Dependency;

namespace VCore.Configuration.Startup
{
    public class VcStartupConfiguration : DictionaryBasedConfig, IVcStartupConfiguration
    {
        public VcStartupConfiguration(IIocManager iocManager)
        {
            IocManager = iocManager;
        }
        public IIocManager IocManager { get; }
        public string DefaultNameOrConnectionString { get; set; }
        public IModuleConfiguration Modules { get; private set; }

        public T Get<T>()
        {
            return GetOrCreate(typeof(T).FullName, () => IocManager.Resolve<T>());
        }

        public void Initialize()
        {
            Modules = IocManager.Resolve<IModuleConfiguration>();
        }
    }
}
