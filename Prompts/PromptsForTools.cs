using System.ComponentModel;
using Microsoft.Extensions.AI;
using ModelContextProtocol.Server;

[McpServerPromptType]
public class PromptExamples
{
    [McpServerPrompt(Name = "date_format_by_country_prompt"), Description("An example prompt for formatting a date by country.")]
    public static IEnumerable<ChatMessage> DateFormatPrompt(
        [Description("Date to format")] string date,
        [Description("Country")] string country)
    {
        //validate inputs
        if (string.IsNullOrWhiteSpace(date))
        {
            throw new ArgumentException("Date cannot be null or empty.", nameof(date));
        }
        //make sure date is in a valid format
        if (!DateTime.TryParse(date, out _))
        {
            throw new ArgumentException("Date is not in a valid format.", nameof(date));
        }

        if (string.IsNullOrWhiteSpace(country))
        {
            throw new ArgumentException("Country cannot be null or empty.", nameof(country));
        }   

        return [
            new ChatMessage(ChatRole.User,$"How would the date {date} be formatted in {country}?"),
        ];
    }
}