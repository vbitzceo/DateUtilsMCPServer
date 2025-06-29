# Date Utils MCP Server

A comprehensive Model Context Protocol (MCP) server that provides extensive date and time utilities for AI assistants and applications.

## Overview

This MCP server offers a rich collection of date and time tools that can be used by AI models and applications through the Model Context Protocol. It provides utilities for getting current dates and times, date manipulation, comparison, and formatting across different formats and countries.

## Features

### Current Date and Time
- **Get Server Date**: Returns the current date based on server timezone in `yyyy-MM-dd` format
- **Get Server Day of Week**: Returns the current day of the week
- **Get Server DateTime**: Returns current local date and time
- **Get Server Day of Year**: Returns the current day of the year (1-366)
- **Get UTC DateTime**: Returns current UTC date and time in ISO 8601 format
- **Get UTC Day of Week**: Returns current UTC day of the week
- **Get UTC Day of Year**: Returns current UTC day of the year

### Date Manipulation
- **Add Days**: Add specified days to current date
- **Add Hours**: Add specified hours to current date and time
- **Add Minutes**: Add specified minutes to current date and time
- **Add Seconds**: Add specified seconds to current date and time
- **Add Weeks**: Add specified weeks to current date
- **Add Months**: Add specified months to current date
- **Add Years**: Add specified years to current date

### Date Comparison
- **Compare Dates**: Compare two dates and determine their relationship (earlier, later, or same)

### Date Formatting
- **Format Date**: Convert a date string to a specific format
- **Get Available Date Formats**: Returns a list of common date formats with descriptions
- **Get Date Formats by Country**: Returns common date formats used by different countries

### Prompts
- **Date Format by Country Prompt**: Example prompt for formatting dates according to country conventions

## Prerequisites

- [.NET 9.0](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- [Node.js](https://nodejs.org/) (for using the MCP inspector)

## Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/DateUtilsMCPServer.git
   cd DateUtilsMCPServer
   ```

2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Build the project**:
   ```bash
   dotnet build
   ```

## Usage

### Running with MCP Inspector

The easiest way to test and interact with the server is using the MCP Inspector:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

This will start the server and open a web interface where you can:
- View available tools
- Test tool execution
- Inspect server capabilities

### Running as Standalone Server

You can also run the server directly:

```bash
dotnet run
```

The server will start and listen for MCP protocol messages on stdin/stdout.

## Available Tools

### Current Date and Time Tools
| Tool Name | Description | Returns |
|-----------|-------------|---------|
| `GetServerDate` | Get today's date based on server timezone | Date in `yyyy-MM-dd` format |
| `GetServerDayOfWeek` | Get today's day of the week | Day name (e.g., "Monday") |
| `GetCurrentServerDateTime` | Get current local date and time of server | Local time in `yyyy-MM-ddTHH:mm:ss` format |
| `GetServerDayOfYear` | Get server's day of the year | Number 1-366 |
| `GetCurrentUTCDateTime` | Get current UTC date and time | ISO 8601 format (`yyyy-MM-ddTHH:mm:ssZ`) |
| `GetCurrentUTCDayOfWeek` | Get current UTC day of week | Day name (e.g., "Monday") |
| `GetCurrentUTCDayOfYear` | Get current UTC day of year | Number 1-366 |

### Date Manipulation Tools
| Tool Name | Description | Parameters | Returns |
|-----------|-------------|------------|---------|
| `AddDaysToCurrentDate` | Add days to current date | `days` (int) | Date in `yyyy-MM-dd` format |
| `AddHoursToCurrentDateTime` | Add hours to current date/time | `hours` (int) | DateTime in `yyyy-MM-ddTHH:mm:ss` format |
| `AddMinutesToCurrentDateTime` | Add minutes to current date/time | `minutes` (int) | DateTime in `yyyy-MM-ddTHH:mm:ss` format |
| `AddSecondsToCurrentDateTime` | Add seconds to current date/time | `seconds` (int) | DateTime in `yyyy-MM-ddTHH:mm:ss` format |
| `AddWeeksToCurrentDate` | Add weeks to current date | `weeks` (int) | Date in `yyyy-MM-dd` format |
| `AddMonthsToCurrentDate` | Add months to current date | `months` (int) | Date in `yyyy-MM-dd` format |
| `AddYearsToCurrentDate` | Add years to current date | `years` (int) | Date in `yyyy-MM-dd` format |

### Date Comparison Tools
| Tool Name | Description | Parameters | Returns |
|-----------|-------------|------------|---------|
| `CompareDates` | Compare two dates | `date1` (string), `date2` (string) | Comparison result string |

### Date Formatting Tools
| Tool Name | Description | Parameters | Returns |
|-----------|-------------|------------|---------|
| `FormatDate` | Format a date to specific format | `date` (string), `format` (string) | Formatted date string |
| `GetAvailableDateFormats` | Get list of available date formats | None | JSON with format descriptions |
| `GetCommonDateFormatsByCountry` | Get date formats by country | None | JSON with country-specific formats |

### Available Prompts
| Prompt Name | Description | Parameters |
|-------------|-------------|------------|
| `date_format_by_country_prompt` | Example prompt for formatting dates by country | `date` (string), `country` (string) |

## Integration

### Using with Claude Desktop

#### Method 1: Using the Docker Image

The easiest way to use this MCP server with Claude Desktop is via the Docker image:

1. **Add to Claude Desktop configuration**:
   
   Edit your Claude Desktop configuration file:
   - **macOS**: `~/Library/Application Support/Claude/claude_desktop_config.json`
   - **Windows**: `%APPDATA%\Claude\claude_desktop_config.json`

2. **Add the MCP server configuration**:
   ```json
   {
     "mcpServers": {
       "date-utils": {
         "command": "docker",
         "args": [
           "run",
           "--rm",
           "-i",
           "vbitzceo/dateutilsmcpserver:latest"
         ]
       }
     }
   }
   ```

3. **Restart Claude Desktop** to load the new configuration.

#### Method 2: Using Local Build

If you prefer to run the server locally without Docker:

1. **Build the project**:
   ```bash
   dotnet build --configuration Release
   ```

2. **Add to Claude Desktop configuration**:
   ```json
   {
     "mcpServers": {
       "date-utils": {
         "command": "dotnet",
         "args": [
           "run",
           "--project",
           "/path/to/DateUtilsMCPServer"
         ]
       }
     }
   }
   ```

#### Method 3: Using the Published Binary

1. **Publish a self-contained executable**:
   ```bash
   dotnet publish -c Release --self-contained -r osx-arm64
   # or for other platforms: win-x64, linux-x64, etc.
   ```

2. **Add to Claude Desktop configuration**:
   ```json
   {
     "mcpServers": {
       "date-utils": {
         "command": "/path/to/DateUtilsMCPServer/bin/Release/net9.0/osx-arm64/publish/DateUtilsMCPServer"
       }
     }
   }
   ```

### Using with Other MCP Clients

The server implements the standard MCP protocol and can be used with any compatible client. Connect to the server using stdio transport.

## Development

### Project Structure

```
DateUtilsMCPServer/
├── Program.cs                    # Main application entry point with MCP server setup
├── Tools/
│   └── CurrentDateTools.cs       # Comprehensive date/time tool implementations
├── Prompts/
│   └── PromptsForTools.cs        # Example prompts for date formatting
├── DateUtilsMCPServer.csproj     # Project file with container support
├── DateUtilsMCPServer.sln        # Solution file
├── global.json                   # .NET SDK version configuration
├── LICENSE                       # MIT License
└── README.md                     # This file
```

### Container Support

This project includes container support with the following configuration:
- **Base Image**: `mcr.microsoft.com/dotnet/runtime:9.0-alpine`
- **Target Architecture**: `linux-arm64` (configurable)
- **Repository**: `vbitzceo/dateutilsmcpserver`

#### Building the Container

To build and publish as a container:
```bash
dotnet publish /t:PublishContainer
```

#### Running the Container

To run the container directly:
```bash
docker run --rm -i vbitzceo/dateutilsmcpserver:latest
```

#### Pulling from Docker Hub

The image is available on Docker Hub:
```bash
docker pull vbitzceo/dateutilsmcpserver:latest
```

#### Architecture Support

To target different architectures, modify the `RuntimeIdentifier` in the `.csproj` file:
- `linux-x64` for x64 Linux
- `linux-arm64` for ARM64 Linux (default)
- `win-x64` for Windows x64

### Adding New Tools

1. Create a new class in the `Tools/` directory
2. Decorate the class with `[McpServerToolType]`
3. Add static methods decorated with `[McpServerTool]` and `[Description]`
4. The server will automatically discover and register your tools

Example:
```csharp
[McpServerToolType]
public sealed class MyCustomTools
{
    [McpServerTool, Description("Description of what this tool does")]
    public static string MyTool(string parameter)
    {
        // Your tool implementation
        return "result";
    }
}
```

### Adding New Prompts

1. Create a new class in the `Prompts/` directory
2. Decorate the class with `[McpServerPromptType]`
3. Add static methods decorated with `[McpServerPrompt]` and `[Description]`
4. Return `IEnumerable<ChatMessage>` for the prompt content

Example:
```csharp
[McpServerPromptType]
public class MyPrompts
{
    [McpServerPrompt(Name = "my_prompt"), Description("Example prompt")]
    public static IEnumerable<ChatMessage> MyPrompt(
        [Description("Input parameter")] string input)
    {
        return [
            new ChatMessage(ChatRole.User, $"Process this: {input}"),
        ];
    }
}
```

## Dependencies

- **Microsoft.Extensions.Hosting** (9.0.6) - For hosting and dependency injection
- **ModelContextProtocol** (0.3.0-preview.1) - Core MCP protocol implementation

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Related Projects

- [Model Context Protocol](https://github.com/modelcontextprotocol/specification) - The official MCP specification
- [MCP Inspector](https://www.npmjs.com/package/@modelcontextprotocol/inspector) - Tool for testing MCP servers

## Support

If you encounter any issues or have questions, please [open an issue](https://github.com/yourusername/DateUtilsMCPServer/issues) on GitHub.