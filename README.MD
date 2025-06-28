# Date Utils MCP Server

A Model Context Protocol (MCP) server that provides date and time utilities for AI assistants and applications.

## Overview

This MCP server offers a collection of date and time tools that can be used by AI models and applications through the Model Context Protocol. It provides utilities for getting current dates, times, and day-of-week information in various formats.

## Features

- **Get Today's Date**: Returns the current date in `yyyy-MM-dd` format
- **Get Day of Week**: Returns the current day of the week
- **Get UTC DateTime**: Returns current UTC date and time in ISO 8601 format
- **Get Local DateTime**: Returns current local date and time

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

| Tool Name | Description | Returns |
|-----------|-------------|---------|
| `GetTodaysDate` | Get today's date | Date in `yyyy-MM-dd` format |
| `GetTodaysDayOfWeek` | Get today's day of the week | Day name (e.g., "Monday") |
| `GetCurrentUTCDateTime` | Get current UTC date and time | ISO 8601 format (`yyyy-MM-ddTHH:mm:ssZ`) |
| `GetCurrentLocalDateTime` | Get current local date and time | Local time in `yyyy-MM-ddTHH:mm:ss` format |

## Integration

### Using with Claude Desktop

Comming soon ....

### Using with Other MCP Clients

The server implements the standard MCP protocol and can be used with any compatible client. Connect to the server using stdio transport.

## Development

### Project Structure

```
DateUtilsMCPServer/
├── Program.cs              # Main application entry point
├── Tools/
│   └── CurrentDateTools.cs # Date/time tool implementations
├── DateUtilsMCPServer.csproj
└── README.md
```

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