using System.ComponentModel;
using ModelContextProtocol.Server;

[McpServerToolType]
public sealed class CurrentDateTimeTools
{
    [McpServerTool, Description("Get today's date.")]
    public static string GetTodaysDate()
    {
        return DateTime.UtcNow.ToString("yyyy-MM-dd");
    }

    [McpServerTool, Description("Get today's day of the week.")]
    public static string GetTodaysDayOfWeek()
    {
        return DateTime.UtcNow.DayOfWeek.ToString();
    }

    [McpServerTool, Description("Get the current UTC date and time in ISO 8601 format.")]
    public static string GetCurrentUTCDateTime()
    {
        return DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
    }
    [McpServerTool, Description("Get the current local date and time")]
    public static string GetCurrentLocalDateTime()
    {
        return DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
    }
}