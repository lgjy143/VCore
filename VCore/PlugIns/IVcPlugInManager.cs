using System;
using System.Collections.Generic;
using System.Text;

namespace VCore.PlugIns
{
    public interface IVcPlugInManager
    {
        PlugInSourceList PlugInSources { get; }
    }
}
