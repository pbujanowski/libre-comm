using System.Net.Mime;
using LibreComm.Services.Messages.Application.Queries.GetMessages;
using MediatR;

namespace LibreComm.Services.Messages.API.Endpoints.GetMessages;

/// <summary>
/// GetMessages endpoint.
/// </summary>
public static class GetMessagesEndpoint
{
    /// <summary>
    /// Registers GetMessages endpoint.
    /// </summary>
    /// <param name="app">Web application.</param>
    /// <returns>Route handler builder.</returns>
    public static RouteHandlerBuilder RegisterGetMessagesEndpoint(this WebApplication app) =>
        app.MapGet(
                "/get-messages/{senderId}",
                async (Guid senderId, IMediator mediator) =>
                {
                    var result = await mediator.Send(new GetMessagesQuery(new(senderId)));
                    return Results.Ok(new GetMessagesResponse(result.Messages));
                }
            )
            .Produces(
                statusCode: StatusCodes.Status200OK,
                responseType: typeof(GetMessagesResponse),
                contentType: MediaTypeNames.Application.Json
            )
            .WithName("GetMessages")
            .WithDescription("GetMessages endpoint.")
            .WithOpenApi();
}
