using System;
using System.Collections.Generic;

namespace VCore.Modules
{
    public interface IVcModuleManager
    {
        VcModuleInfo StartupModule { get; }

        IReadOnlyList<VcModuleInfo> Modules { get; }

        void Initialize(Type startupModule);

        void StartModules();

        void ShutdownModules();
    }
}
