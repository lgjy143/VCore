using Shouldly;
using System.Linq;
using System.Reflection;
using VCore.Modules;
using VCore.Reflection;
using Xunit;

namespace VCore.Test.Modules
{
    public class VcAssemblyFinder_Tests : TestBaseWithLocalIocManager
    {
        [Fact]
        public void Should_Get_Module_And_Additional_Assemblies()
        {
            //Arrange
            var bootstrapper = VcBootstrapper.Create<MyStartupModule>(options =>
            {
                options.IocManager = LocalIocManager;
            });

            bootstrapper.Initialize();

            //Act
            var assemblies = bootstrapper.IocManager.Resolve<VcAssemblyFinder>().GetAllAssemblies();

            //Assert
            assemblies.Count.ShouldBe(3);

            assemblies.Any(a => a == typeof(MyStartupModule).GetAssembly()).ShouldBeTrue();
            assemblies.Any(a => a == typeof(VcKernelModule).GetAssembly()).ShouldBeTrue();
            assemblies.Any(a => a == typeof(FactAttribute).GetAssembly()).ShouldBeTrue();
        }

        public class MyStartupModule : VcModule
        {
            public override Assembly[] GetAdditionalAssemblies()
            {
                return new[] { typeof(FactAttribute).GetAssembly() };
            }
        }
    }
}
