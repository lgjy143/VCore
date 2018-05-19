using System;
using System.Collections.Generic;
using System.Text;
using VCore.Dependency;

namespace VCore.Configuration.Startup
{
    public interface IVcStartupConfiguration : IDictionaryBasedConfig
    {
        string DefaultNameOrConnectionString { get; set; }
        IIocManager IocManager { get; }
        IModuleConfiguration Modules { get; }
        void ReplaceService(Type type, Action replaceAction);
    }
}
