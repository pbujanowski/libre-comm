using System.Net.Mime;
using LibreComm.Services.Messages.Application.DeleteMessage;
using MediatR;

namespace LibreComm.Services.Messages.API.Endpoints.DeleteMessage;

/// <summary>
/// DeleteMessage endpoint.
/// </summary>
public static class DeleteMessageEndpoint
{
    /// <summary>
    /// Registers DeleteMessage endpoint.
    /// </summary>
    /// <param name="app">Web application.</param>
    /// <returns>Route handler builder.</returns>
    public static RouteHandlerBuilder RegisterDeleteMessageEndpoint(this WebApplication app) =>
        app.MapDelete(
                "/delete-message/{id}",
                async (Guid id, IMediator mediator) =>
                {
                    var result = await mediator.Send(new DeleteMessageCommand(new(id)));
                    return Results.Ok(new DeleteMessageResponse(result.Count));
                }
            )
            .Produces(
                statusCode: StatusCodes.Status200OK,
                responseType: typeof(DeleteMessageResponse),
                contentType: MediaTypeNames.Application.Json
            )
            .WithName("DeleteMessage")
            .WithDescription("DeleteMessage endpoint.")
            .WithOpenApi();
}
