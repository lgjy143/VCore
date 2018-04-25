using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using VCore.Dependency.Autofac;
using Xunit;

namespace VCore.Test
{
    public class IocManagerTest
    {
        public IocManagerTest()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IocManagerTest1>();
            var builder = new ContainerBuilder();//实例化 AutoFac  容器              
            builder.Populate(services);

            var autofacContainer = new AutofacContainer(builder);

            VCore.Dependency.IocContainer.IocContainer.SetContainer(autofacContainer);

            autofacContainer.Build();

            //var ApplicationContainer = builder.Build();
        }

        [Fact]
        public void Register()
        {
            var resolveObj = VCore.Dependency.IocContainer.IocContainer.Instance.Resolve(typeof(IocManagerTest1));

            VCore.Dependency.IocContainer.IocContainer.Instance.Register(typeof(IocManagerTest));

            var isRegistered = VCore.Dependency.IocContainer.IocContainer.Instance.IsRegistered(typeof(IocManagerTest));

            var resolveObj0 = VCore.Dependency.IocContainer.IocContainer.Instance.Resolve(typeof(IocManagerTest));

            //VCore.Dependency.IocManager.Instance.Register(this.GetType());

            //var resolveObj = VCore.Dependency.IocManager.Instance.Resolve(this.GetType());
        }

        public class IocManagerTest1
        {
            public void Write()
            {
                Console.WriteLine("IocManagerTest1.Write");
            }
        }
    }
}
