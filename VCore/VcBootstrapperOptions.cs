using VCore.Dependency;
using VCore.PlugIns;

namespace VCore
{
    public class VcBootstrapperOptions
    {
        /// <summary>
        /// Used to disable all interceptors added by VCore.
        /// </summary>
        public bool DisableAllInterceptors { get; set; }

        /// <summary>
        /// IIocManager that is used to bootstrap the VCore system. If set to null, uses global <see cref="VCore.Dependency.IocManager.Instance"/>
        /// </summary>
        public IIocManager IocManager { get; set; }

        /// <summary>
        /// List of plugin sources.
        /// </summary>
        public PlugInSourceList PlugInSources { get; }

        public VcBootstrapperOptions()
        {
            IocManager = VCore.Dependency.IocManager.Instance;
            PlugInSources = new PlugInSourceList();
        }
    }
}
