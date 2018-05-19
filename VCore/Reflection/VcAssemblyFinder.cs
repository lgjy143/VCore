using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VCore.Modules;

namespace VCore.Reflection
{
    public class VcAssemblyFinder : IAssemblyFinder
    {
        private readonly IVcModuleManager _moduleManager;

        public VcAssemblyFinder(IVcModuleManager moduleManager)
        {
            _moduleManager = moduleManager;
        }

        public IList<Assembly> GetAllAssemblies()
        {
            var assemblies = new List<Assembly>();

            foreach (var module in _moduleManager.Modules)
            {
                assemblies.Add(module.Assembly);
                assemblies.AddRange(module.Instance.GetAdditionalAssemblies());
            }

            return assemblies.Distinct().ToList();
        }
    }
}
