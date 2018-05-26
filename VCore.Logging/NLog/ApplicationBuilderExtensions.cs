using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using NLog;
using NLog.Config;
using NLog.Web;
using System.IO;

namespace VCore.Logging.NLog
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder ConfigureNLog(this IApplicationBuilder app, IHostingEnvironment env)
        {
            LogManager.Configuration = new XmlLoggingConfiguration(Path.Combine(env.ContentRootPath, "nlog.config"));
            LogManager.Configuration.Variables["root"] = env.ContentRootPath;

            //env.ConfigureNLog("");

            return app;
        }
    }
}
