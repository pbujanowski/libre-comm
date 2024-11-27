using System.Net.Mime;

namespace LibreComm.Services.Messages.API.Endpoints.Index;

/// <summary>
/// Index endpoint.
/// </summary>
public static class IndexEndpoint
{
    /// <summary>
    /// Registers Index endpoint.
    /// </summary>
    /// <param name="app">Web application.</param>
    /// <returns>Route handler builder.</returns>
    public static RouteHandlerBuilder RegisterIndexEndpoint(this WebApplication app) =>
        app.MapGet("/", () => Results.Ok(new IndexResponse("Hello from \"Messages\" service!")))
            .Produces(
                statusCode: StatusCodes.Status200OK,
                responseType: typeof(IndexResponse),
                contentType: MediaTypeNames.Application.Json
            )
            .WithName("Index")
            .WithDescription("Index endpoint.")
            .WithOpenApi();
}
