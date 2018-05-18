using System;

namespace VCore.Dependency.IocContainers
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class UninjectPropertiesAttribute : Attribute
    {
    }
}
