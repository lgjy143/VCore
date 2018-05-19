using System;
using System.Collections.Generic;
using System.Text;

namespace VCore.PlugIns
{
    public class VcPlugInManager : IVcPlugInManager
    {
        public VcPlugInManager()
        {
            PlugInSources = new PlugInSourceList();
        }

        public PlugInSourceList PlugInSources { get; }
    }
}
