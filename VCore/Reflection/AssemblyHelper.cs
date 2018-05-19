using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace VCore.Reflection
{
    internal static class AssemblyHelper
    {
        public static List<Assembly> GetAllAssembliesInFolder(string folderPath, SearchOption searchOption)
        {
            var assemblyFiles = Directory
                .EnumerateFiles(folderPath, "*.*", searchOption)
                .Where(s => s.EndsWith(".dll") || s.EndsWith(".exe"));
            // var asl = new AssemblyLoader();
            // var asm = asl.LoadFromAssemblyPath(@"C:\Location\Of\" + "SampleClassLib.dll");

            // TODO Fix
            // return assemblyFiles.Select(asl.LoadFromAssemblyPath).ToList();
            return null;
        }
    }
}
