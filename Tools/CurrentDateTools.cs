using System.ComponentModel;
using ModelContextProtocol.Server;

[McpServerToolType]
public sealed class CurrentDateTimeTools
{
    #region region Current Date and Time
    [McpServerTool, Description("Get today's date based on the server's timezone.")]
    public static string GetServerDate()
    {
        return DateTime.Now.ToString("yyyy-MM-dd");
    }

    [McpServerTool, Description("Get today's day of the week.")]
    public static string GetServerDayOfWeek()
    {
        return DateTime.Now.DayOfWeek.ToString();
    }

    [McpServerTool, Description("Get the current local date and time of the server")]
    public static string GetCurrentServerDateTime()
    {
        return DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
    }

    [McpServerTool, Description("Get the server's day of the year.")]
    public static string GetServerDayOfYear()
    {
        return DateTime.Now.DayOfYear.ToString();
    }

    [McpServerTool, Description("Get the current UTC date and time.")]
    public static string GetCurrentUTCDateTime()
    {
        return DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
    }

    [McpServerTool, Description("Get the current UTC day of week.")]
    public static string GetCurrentUTCDayOfWeek()
    {
        return DateTime.UtcNow.DayOfWeek.ToString();
    }

    [McpServerTool, Description("Get the current UTC day of year.")]
    public static string GetCurrentUTCDayOfYear()
    {
        return DateTime.UtcNow.DayOfYear.ToString();
    }
    #endregion

    #region region DateTime Manipulation
    [McpServerTool, Description("Add days to the current date.")]
    public static string AddDaysToCurrentDate(int days)
    {
        return DateTime.UtcNow.AddDays(days).ToString("yyyy-MM-dd");
    }
    [McpServerTool, Description("Add hours to the current date and time.")]
    public static string AddHoursToCurrentDateTime(int hours)
    {
        return DateTime.UtcNow.AddHours(hours).ToString("yyyy-MM-ddTHH:mm:ss");
    }
    [McpServerTool, Description("Add minutes to the current date and time.")]
    public static string AddMinutesToCurrentDateTime(int minutes)
    {
        return DateTime.UtcNow.AddMinutes(minutes).ToString("yyyy-MM-ddTHH:mm:ss");
    }
    [McpServerTool, Description("Add seconds to the current date and time.")]
    public static string AddSecondsToCurrentDateTime(int seconds)
    {
        return DateTime.UtcNow.AddSeconds(seconds).ToString("yyyy-MM-ddTHH:mm:ss");
    }
    [McpServerTool, Description("Add weeks to the current date.")]
    public static string AddWeeksToCurrentDate(int weeks)
    {
        return DateTime.UtcNow.AddDays(weeks * 7).ToString("yyyy-MM-dd");
    }
    [McpServerTool, Description("Add months to the current date.")]
    public static string AddMonthsToCurrentDate(int months)
    {
        return DateTime.UtcNow.AddMonths(months).ToString("yyyy-MM-dd");
    }
    [McpServerTool, Description("Add years to the current date.")]
    public static string AddYearsToCurrentDate(int years)
    {
        return DateTime.UtcNow.AddYears(years).ToString("yyyy-MM-dd");
    }
    #endregion

    #region region DateTime Comparison
    [McpServerTool, Description("Compare two dates and return if the first is earlier, later, or the same as the second.")]
    public static string CompareDates(string date1, string date2)
    {
        DateTime dt1 = DateTime.Parse(date1);
        DateTime dt2 = DateTime.Parse(date2);
        if (dt1 < dt2)
        {
            return $"{dt1} is earlier than {dt2}";
        }
        else if (dt1 > dt2)
        {
            return $"{dt1} is later than {dt2}";
        }
        else
        {
            return $"{dt1} is the same as {dt2}";
        }
    }
    #endregion

    #region region DateTime Formatting
    [McpServerTool, Description("Format a date string to a specific format.")]
    public static string FormatDate(string date, string format)
    {
        DateTime dt = DateTime.Parse(date);
        return dt.ToString(format);
    }

    //return a list of available date formats with descriptions
    [McpServerTool, Description("Get a list of available date formats.")]
    public static string GetAvailableDateFormats()
    {
        //return a list of available date formats with descriptions
        return @"{
            ""formats"": [
                { ""format"": ""yyyy-MM-dd"", ""description"": ""Year-Month-Day"" },
                { ""format"": ""MM/dd/yyyy"", ""description"": ""Month/Day/Year"" },
                { ""format"": ""dd-MM-yyyy"", ""description"": ""Day-Month-Year"" },
                { ""format"": ""yyyy-MM-ddTHH:mm:ss"", ""description"": ""Year-Month-DayTHour:Minute:Second"" },
                { ""format"": ""MM/dd/yyyy HH:mm:ss"", ""description"": ""Month/Day/Year Hour:Minute:Second"" }
            ]
        }";
    }

    // return a list of common date formats by country
    [McpServerTool, Description("Get a list of common date formats by country.")]
    public static string GetCommonDateFormatsByCountry()
    {
        //return a list of common date formats by country
        return @"{
            ""countries"": [
                { ""country"": ""US"", ""formats"": [""MM/dd/yyyy"", ""yyyy-MM-dd""] },
                { ""country"": ""UK"", ""formats"": [""dd/MM/yyyy"", ""yyyy-MM-dd""] },
                { ""country"": ""DE"", ""formats"": [""dd.MM.yyyy"", ""yyyy-MM-dd""] },
                { ""country"": ""FR"", ""formats"": [""dd/MM/yyyy"", ""yyyy-MM-dd""] },
                { ""country"": ""JP"", ""formats"": [""yyyy/MM/dd"", ""dd/MM/yyyy""] },
                { ""country"": ""CN"", ""formats"": [""yyyy-MM-dd"", ""dd/MM/yyyy""] },
                { ""country"": ""IN"", ""formats"": [""dd-MM-yyyy"", ""yyyy-MM-dd""] },
                { ""country"": ""BR"", ""formats"": [""dd/MM/yyyy"", ""yyyy-MM-dd""] },
                { ""country"": ""ZA"", ""formats"": [""yyyy-MM-dd"", ""dd/MM/yyyy""] },
                { ""country"": ""AU"", ""formats"": [""dd/MM/yyyy"", ""yyyy-MM-dd""] }
            ]
            }";
    }
    #endregion
}                                                                            
