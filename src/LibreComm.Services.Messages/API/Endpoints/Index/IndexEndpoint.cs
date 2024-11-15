namespace LibreComm.Services.Messages.API.Endpoints.Index;

/// <summary>
/// Index endpoint.
/// </summary>
public static class IndexEndpoint
{
    public static RouteHandlerBuilder RegisterIndexEndpoint(this WebApplication app) =>
        app.MapGet("/", () => Results.Ok("Hello from \"Messages\" service!"))
            .WithName("Index")
            .WithDescription("Index endpoint.")
            .WithOpenApi();
}
