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
        public static void LogError<T>(this ILogger<T> logger, Exception e, string methodName)
        {
            logger.LogError(e, $"{methodName} failed. {e.Message}.");
        }
        public static void LogError<T>(this ILogger<T> logger, Exception e, string methodName, string errorMessage, object input)
        {
            logger.LogError(e, $"{methodName} failed. {errorMessage}. Inputs: {input}");
        }

    }
}
