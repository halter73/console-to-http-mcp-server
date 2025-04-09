using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    // Set the port for the server to listen on
    options.ListenLocalhost(3001);
});
builder.Services
    .AddMcpServer()
    .WithToolsFromAssembly();

var app = builder.Build();

app.MapMcp();

app.Run();

[McpServerToolType]
public static class EchoTool
{
    [McpServerTool, Description("Echoes the message back to the client.")]
    public static string Echo(string message) => $"hello {message}";
}
