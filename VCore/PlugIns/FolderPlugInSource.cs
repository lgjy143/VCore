using System;
using System.Collections.Generic;
using System.IO;
using VCore.Extensions;
using VCore.Modules;
using VCore.Reflection;

namespace VCore.PlugIns
{
    public class FolderPlugInSource : IPlugInSource
    {
        public FolderPlugInSource(string folder, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            Folder = folder;
            SearchOption = searchOption;
        }

        public string Folder { get; }

        public SearchOption SearchOption { get; set; }

        public List<Type> GetModules()
        {
            var modules = new List<Type>();

            var assemblies = AssemblyHelper.GetAllAssembliesInFolder(Folder, SearchOption);
            foreach (var assembly in assemblies)
            {
                try
                {
                    foreach (var type in assembly.GetTypes())
                    {
                        if (VcModule.IsVcModule(type))
                        {
                            modules.AddIfNotContains(type);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new VcInitializationException($"Could not get module types from assembly: {assembly.FullName}", ex);
                }
            }

            return modules;
        }
    }
}
