using VCore.Configuration;

namespace VCore.Dependency
{
    public class ConventionalRegistrationConfig : DictionaryBasedConfig
    {
        public ConventionalRegistrationConfig()
        {
            InstallInstallers = true;
        }

        public bool InstallInstallers { get; set; }
    }
}
