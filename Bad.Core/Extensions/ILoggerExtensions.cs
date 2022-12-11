using Microsoft.Extensions.Logging;
using System;

namespace Bad.Core.Extensions
{
    public static class ILoggerExtensions
    {
        public static void LogError<T>(this ILogger<T> logger, Exception e)
        {
            logger.LogError(e, e.Message);
        }

    }
}
