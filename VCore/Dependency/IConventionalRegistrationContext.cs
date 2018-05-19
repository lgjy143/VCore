using System.Reflection;

namespace VCore.Dependency
{
    public interface IConventionalRegistrationContext
    {
        Assembly Assembly { get; }

        IIocManager IocManager { get; }

        ConventionalRegistrationConfig Config { get; }
    }
}
