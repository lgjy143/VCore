using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using VCore.Configuration.Startup;
using VCore.Dependency.IocContainers;
using VCore.Modules;
using VCore.PlugIns;

namespace VCore.Dependency.Installers
{
    public class VcCoreInstaller : IIocInstaller
    {
        public void Install(IIocContainer container)
        {
            //TODO: Fix
            container.Register(builder =>
            {
                builder.RegisterType<ModuleConfiguration>().As<IModuleConfiguration>().AsSelf().LifestyleSingleton();

                builder.RegisterType<VcPlugInManager>().As<IVcPlugInManager>().AsSelf().LifestyleSingleton();
                builder.RegisterType<VcModuleManager>().As<IVcModuleManager>().AsSelf().LifestyleSingleton().PropertiesAutowired();
            });
        }
    }
}
