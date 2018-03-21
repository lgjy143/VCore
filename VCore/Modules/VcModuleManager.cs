using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using VCore.Dependency;

namespace VCore.Modules
{
    public class VcModuleManager : IVcModuleManager
    {
        public VcModuleInfo StartupModule { get; private set; }

        public IReadOnlyList<VcModuleInfo> Modules => _modules.ToImmutableList();

        public ILogger Logger { get; set; }

        private VcModuleCollection _modules;

        private readonly IIocManager _iocManager;
        public VcModuleManager(IIocManager iocManager)
        {
            _iocManager = iocManager;
            Logger = NullLogger.Instance;
        }

        //private readonly IAbpPlugInManager _vcPlugInManager;

        //public VcModuleManager(IIocManager iocManager, IVcPlugInManager vcPlugInManager)
        //{
        //    _iocManager = iocManager;
        //    _vcPlugInManager = vcPlugInManager;

        //    Logger = NullLogger.Instance;
        //}

        public virtual void Initialize(Type startupModule)
        {
            _modules = new VcModuleCollection(startupModule);
            LoadAllModules();
        }

        public virtual void StartModules()
        {
            var sortedModules = _modules.GetSortedModuleListByDependency();
            sortedModules.ForEach(module => module.Instance.PreInitialize());
            sortedModules.ForEach(module => module.Instance.Initialize());
            sortedModules.ForEach(module => module.Instance.PostInitialize());
        }

        public virtual void ShutdownModules()
        {
            Logger.LogDebug("Shutting down has been started");

            var sortedModules = _modules.GetSortedModuleListByDependency();
            sortedModules.Reverse();
            sortedModules.ForEach(sm => sm.Instance.Shutdown());

            Logger.LogDebug("Shutting down completed.");
        }

        private void LoadAllModules()
        {
            Logger.LogDebug("Loading VC modules...");

            List<Type> plugInModuleTypes;
            var moduleTypes = FindAllModuleTypes(out plugInModuleTypes).Distinct().ToList();

            Logger.LogDebug("Found " + moduleTypes.Count + " VC modules in total.");

            RegisterModules(moduleTypes);
            CreateModules(moduleTypes, plugInModuleTypes);

            _modules.EnsureKernelModuleToBeFirst();
            _modules.EnsureStartupModuleToBeLast();

            SetDependencies();

            Logger.LogDebug($"{_modules.Count} modules loaded.");
        }

        private List<Type> FindAllModuleTypes(out List<Type> plugInModuleTypes)
        {
            plugInModuleTypes = new List<Type>();

            var modules = VcModule.FindDependedModuleTypesRecursivelyIncludingGivenModule(_modules.StartupModuleType);

            //foreach (var plugInModuleType in _vcPlugInManager.PlugInSources.GetAllModules())
            //{
            //    if (modules.AddIfNotContains(plugInModuleType))
            //    {
            //        plugInModuleTypes.Add(plugInModuleType);
            //    }
            //}

            return modules;
        }

        private void CreateModules(ICollection<Type> moduleTypes, List<Type> plugInModuleTypes)
        {
            foreach (var moduleType in moduleTypes)
            {
                var moduleObject = IIocManager.Resolve(moduleType) as VcModule;
                if (moduleObject == null)
                {
                    throw new VcInitializationException("This type is not an VC module: " + moduleType.AssemblyQualifiedName);
                }

                moduleObject.IocManager = _iocManager;
                //moduleObject.Configuration = _iocManager.Resolve<IAbpStartupConfiguration>();

                var moduleInfo = new VcModuleInfo(moduleType, moduleObject, plugInModuleTypes.Contains(moduleType));

                _modules.Add(moduleInfo);

                if (moduleType == _modules.StartupModuleType)
                {
                    StartupModule = moduleInfo;
                }

                Logger.LogDebug("Loaded module: " + moduleType.AssemblyQualifiedName);
            }
        }

        private void RegisterModules(ICollection<Type> moduleTypes)
        {
            foreach (var moduleType in moduleTypes)
            {
                _iocManager.RegisterIfNot(moduleType);
            }
        }

        private void SetDependencies()
        {
            foreach (var moduleInfo in _modules)
            {
                moduleInfo.Dependencies.Clear();

                //Set dependencies for defined DependsOnAttribute attribute(s).
                foreach (var dependedModuleType in VcModule.FindDependedModuleTypes(moduleInfo.Type))
                {
                    var dependedModuleInfo = _modules.FirstOrDefault(m => m.Type == dependedModuleType);
                    if (dependedModuleInfo == null)
                    {
                        throw new VcInitializationException("Could not find a depended module " + dependedModuleType.AssemblyQualifiedName + " for " + moduleInfo.Type.AssemblyQualifiedName);
                    }

                    if ((moduleInfo.Dependencies.FirstOrDefault(dm => dm.Type == dependedModuleType) == null))
                    {
                        moduleInfo.Dependencies.Add(dependedModuleInfo);
                    }
                }
            }
        }
    }
}
