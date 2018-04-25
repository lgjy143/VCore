using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using VCore.Dependency.IocContainer;

namespace VCore.Dependency
{
    public interface IIocManager : IIocResolver, IIocRegistrar
    {
        /// <summary>
        /// Reference to the Container.
        /// </summary>
        IIocContainer IocContainer { get; }
    }
}
