using System.Collections.Generic;
using System.Reflection;

namespace VCore.Reflection
{
    public interface IAssemblyFinder
    {
        IList<Assembly> GetAllAssemblies();
    }
}
