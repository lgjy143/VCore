using System;
using System.Collections.Generic;
using System.Text;

namespace VCore.Dependency
{
    public interface IConventionalDependencyRegistrar
    {
        void RegisterAssembly(IConventionalRegistrationContext context);
    }
}
