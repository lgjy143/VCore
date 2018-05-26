using Microsoft.Extensions.Logging;
using System;

namespace VCore.Logging
{
    public static class LoggerExtensions
    {
        public static void Log(this ILogger logger, LogSeverity severity, string message)
        {
            switch (severity)
            {
                case LogSeverity.Fatal:
                    logger.LogCritical(message);
                    break;
                case LogSeverity.Error:
                    logger.LogError(message);
                    break;
                case LogSeverity.Warn:
                    logger.LogWarning(message);
                    break;
                case LogSeverity.Info:
                    logger.LogInformation(message);
                    break;
                case LogSeverity.Debug:
                    logger.LogDebug(message);
                    break;
                default:
                    throw new VcException("Unknown LogSeverity value: " + severity);
            }
        }

        public static void Log(this ILogger logger, LogSeverity severity, string message, Exception exception)
        {
            switch (severity)
            {
                case LogSeverity.Fatal:
                    logger.LogCritical(message, exception);
                    break;
                case LogSeverity.Error:
                    logger.LogError(message, exception);
                    break;
                case LogSeverity.Warn:
                    logger.LogWarning(message, exception);
                    break;
                case LogSeverity.Info:
                    logger.LogInformation(message, exception);
                    break;
                case LogSeverity.Debug:
                    logger.LogDebug(message, exception);
                    break;
                default:
                    throw new VcException("Unknown LogSeverity value: " + severity);
            }
        }

        //public static void Log(this ILogger logger, LogSeverity severity, Func<string> messageFactory)
        //{
        //    switch (severity)
        //    {
        //        case LogSeverity.Fatal:
        //            logger.LogCritical(messageFactory);
        //            break;
        //        case LogSeverity.Error:
        //            logger.LogError(messageFactory);
        //            break;
        //        case LogSeverity.Warn:
        //            logger.LogWarning(messageFactory);
        //            break;
        //        case LogSeverity.Info:
        //            logger.LogInformation(messageFactory);
        //            break;
        //        case LogSeverity.Debug:
        //            logger.LogDebug(messageFactory);
        //            break;
        //        default:
        //            throw new VcException("Unknown LogSeverity value: " + severity);
        //    }
        //}
    }
}
