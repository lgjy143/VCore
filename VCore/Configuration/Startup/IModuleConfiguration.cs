using System;
using System.Collections.Generic;
using System.Text;

namespace VCore.Configuration.Startup
{
    public interface IModuleConfiguration
    {
        IVcStartupConfiguration Configuration { get; }
    }
}
