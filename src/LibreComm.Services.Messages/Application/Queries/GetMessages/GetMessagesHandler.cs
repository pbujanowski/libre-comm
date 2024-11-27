using LibreComm.Services.Messages.Application.Services;
using MediatR;

namespace LibreComm.Services.Messages.Application.Queries.GetMessages;

/// <summary>
/// GetMessages handler.
/// </summary>
/// <param name="messageService">Message service.</param>
public class GetMessagesHandler(IMessageService messageService)
    : IRequestHandler<GetMessagesQuery, GetMessagesResult>
{
    /// <summary>
    /// Handles GetMessages query.
    /// </summary>
    /// <param name="request">Query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Result.</returns>
    public async Task<GetMessagesResult> Handle(
        GetMessagesQuery request,
        CancellationToken cancellationToken
    )
    {
        var messages = await messageService.GetMessagesAsync(request.Parameters, cancellationToken);
        return new(messages);
    }
}
