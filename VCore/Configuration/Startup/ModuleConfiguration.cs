namespace VCore.Configuration.Startup
{
    public class ModuleConfiguration : IModuleConfiguration
    {
        public ModuleConfiguration(IVcStartupConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IVcStartupConfiguration Configuration { get; }
    }
}
