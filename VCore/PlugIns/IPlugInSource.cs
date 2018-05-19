using System;
using System.Collections.Generic;

namespace VCore.PlugIns
{
    public interface IPlugInSource
    {
        List<Type> GetModules();
    }
}
