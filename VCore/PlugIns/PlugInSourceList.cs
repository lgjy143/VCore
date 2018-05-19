using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCore.PlugIns
{
    public class PlugInSourceList : List<IPlugInSource>
    {
        public List<Type> GetAllModules()
        {
            return this
                .SelectMany(pluginSource => pluginSource.GetModulesWithAllDependencies())
                .Distinct()
                .ToList();
        }
    }
}
