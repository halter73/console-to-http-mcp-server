using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer()
    .WithToolsFromAssembly();

var app = builder.Build();

app.MapMcp();

app.Run("http://localhost:3001");

[McpServerToolType]
public static class EchoTool
{
    [McpServerTool, Description("Echoes the message back to the client.")]
    public static string Echo(string message) => $"hello {message}";
}
