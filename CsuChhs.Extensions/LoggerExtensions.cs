using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace CsuChhs.Extensions;

public static class LoggerExtensions
{
    public static void LogTraceContext<T>(this ILogger<T> logger,
        string message,
        Exception? exception = null,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        logger.LogTrace(new EventId(),
            $"{message} (at {Path.GetFileName(filePath)}:{memberName}:{lineNumber})",
            exception);
    }
    
    public static void LogDebugContext<T>(this ILogger<T> logger,
        string message,
        Exception? exception = null,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        logger.LogDebug(new EventId(),
            $"{message} (at {Path.GetFileName(filePath)}:{memberName}:{lineNumber})",
            exception);
    }
    
    public static void LogInfoContext<T>(this ILogger<T> logger,
        string message,
        Exception? exception = null,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        logger.LogInformation(new EventId(),
            $"{message} (at {Path.GetFileName(filePath)}:{memberName}:{lineNumber})",
            exception);
    }
    
    public static void LogWarningContext<T>(this ILogger<T> logger,
        string message,
        Exception? exception = null,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        logger.LogWarning(new EventId(),
            $"{message} (at {Path.GetFileName(filePath)}:{memberName}:{lineNumber})",
            exception);
    }
    
    public static void LogErrorContext<T>(this ILogger<T> logger,
        string message,
        Exception? exception = null,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        logger.LogError(new EventId(),
            $"{message} (at {Path.GetFileName(filePath)}:{memberName}:{lineNumber})",
            exception);
    }
    
    public static void LogCriticalContext<T>(this ILogger<T> logger,
        string message,
        Exception? exception = null,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        logger.LogCritical(new EventId(),
            $"{message} (at {Path.GetFileName(filePath)}:{memberName}:{lineNumber})",
            exception);
    }
}