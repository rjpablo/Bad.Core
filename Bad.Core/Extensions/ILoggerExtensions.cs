using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace Bad.Core.Extensions
{
    public static class ILoggerExtensions
    {
        public static void LogError<T>(this ILogger<T> logger, Exception e)
        {
            logger.LogError(e, e.Message);
        }
        public static void LogError<T>(this ILogger<T> logger, Exception e, string errorMessage, string methodName, object input)
        {
            logger.LogError(e, $"{methodName} failed. {errorMessage}. Inputs: {JsonConvert.SerializeObject(input)}");
        }
        public static void LogWarning<T>(this ILogger<T> logger, Exception e)
        {
            logger.LogWarning(e, e.Message);
        }
        public static void LogWarning<T>(this ILogger<T> logger, Exception e, string errorMessage, string methodName, object input)
        {
            logger.LogWarning(e, $"{methodName} failed. {errorMessage}. Inputs: {JsonConvert.SerializeObject(input)}");
        }

    }
}
