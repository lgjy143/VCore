using Shouldly;
using System.Linq;
using VCore.Modules;
using VCore.PlugIns;
using Xunit;

namespace VCore.Test.Modules
{
    public class PlugInModuleLoading_Tests : TestBaseWithLocalIocManager
    {
        [Fact]
        public void Should_Load_All_Modules()
        {
            //Arrange
            var bootstrapper = VcBootstrapper.Create<MyStartupModule>(options =>
            {
                options.IocManager = LocalIocManager;
            });

            bootstrapper.PlugInSources.AddTypeList(typeof(MyPlugInModule));

            bootstrapper.Initialize();

            //Act
            var modules = bootstrapper.IocManager.Resolve<IVcModuleManager>().Modules;

            //Assert
            modules.Count.ShouldBe(6);

            modules.Any(m => m.Type == typeof(VcKernelModule)).ShouldBeTrue();
            modules.Any(m => m.Type == typeof(MyStartupModule)).ShouldBeTrue();
            modules.Any(m => m.Type == typeof(MyModule1)).ShouldBeTrue();
            modules.Any(m => m.Type == typeof(MyModule2)).ShouldBeTrue();
            modules.Any(m => m.Type == typeof(MyPlugInModule)).ShouldBeTrue();
            modules.Any(m => m.Type == typeof(MyPlugInDependedModule)).ShouldBeTrue();

            modules.Any(m => m.Type == typeof(MyNotDependedModule)).ShouldBeFalse();
        }

        [DependsOn(typeof(MyModule1), typeof(MyModule2))]
        public class MyStartupModule : VcModule
        {

        }

        public class MyModule1 : VcModule
        {

        }

        public class MyModule2 : VcModule
        {

        }

        public class MyNotDependedModule : VcModule
        {

        }

        [DependsOn(typeof(MyPlugInDependedModule))]
        public class MyPlugInModule : VcModule
        {

        }

        public class MyPlugInDependedModule : VcModule
        {

        }
    }
}
