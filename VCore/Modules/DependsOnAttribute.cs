using System;

namespace VCore.Modules
{
    /// <summary>
    /// 用于定义VC模块与其他模块的依赖关系.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependsOnAttribute : Attribute
    {
        /// <summary>
        /// 依赖模块的类型.
        /// </summary>
        public Type[] DependedModuleTypes { get; private set; }
        /// <summary>
        /// 定义VC模块与其他模块的依赖关系.
        /// </summary>
        /// <param name="dependedModuleTypes"></param>
        public DependsOnAttribute(params Type[] dependedModuleTypes)
        {
            DependedModuleTypes = dependedModuleTypes;
        }
    }
}
