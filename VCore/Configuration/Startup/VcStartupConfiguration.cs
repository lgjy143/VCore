using System;
using System.Collections.Generic;
using System.Text;
using VCore.Dependency;

namespace VCore.Configuration.Startup
{
    public class VcStartupConfiguration : DictionaryBasedConfig, IVcStartupConfiguration
    {
        public IIocManager IocManager { get; }
        public string DefaultNameOrConnectionString { get; set; }
        public IModuleConfiguration Modules { get; private set; }
        public Dictionary<Type, Action> ServiceReplaceActions { get; private set; }
        public void ReplaceService(Type type, Action replaceAction)
        {
            ServiceReplaceActions[type] = replaceAction;
        }
        public T Get<T>()
        {
            return GetOrCreate(typeof(T).FullName, () => IocManager.Resolve<T>());
        }
        public VcStartupConfiguration(IIocManager iocManager)
        {
            IocManager = iocManager;
        }
        public void Initialize()
        {
            Modules = IocManager.Resolve<IModuleConfiguration>();

            ServiceReplaceActions = new Dictionary<Type, Action>();
        }
    }
}
