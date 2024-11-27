using LibreComm.Services.Messages.API.Endpoints.CreateMessage;
using LibreComm.Services.Messages.API.Endpoints.DeleteMessage;
using LibreComm.Services.Messages.API.Endpoints.GetMessages;
using LibreComm.Services.Messages.API.Endpoints.Index;

namespace LibreComm.Services.Messages.API;

/// <summary>
/// API layer dependency injection.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers API in web application.
    /// </summary>
    /// <param name="app">Web application.</param>
    /// <returns>Web application.</returns>
    public static WebApplication UseAPI(this WebApplication app)
    {
        app.RegisterCreateMessageEndpoint();
        app.RegisterDeleteMessageEndpoint();
        app.RegisterGetMessagesEndpoint();
        app.RegisterIndexEndpoint();

        return app;
    }
}
