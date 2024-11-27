using LibreComm.Services.Common.Application.Models;

namespace LibreComm.Services.Messages.Application.Services;

/// <summary>
/// Message service.
/// </summary>
public interface IMessageService
{
    /// <summary>
    /// Creates a message.
    /// </summary>
    /// <param name="message">Message.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Created message.</returns>
    Task<MessageModel> CreateMessageAsync(
        CreateMessageModel message,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a message.
    /// </summary>
    /// <param name="message">Message.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Deleted message.</returns>
    Task<long> DeleteMessageAsync(
        DeleteMessageModel message,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Gets messages.
    /// </summary>
    /// <param name="parameters">Parameters.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Messages.</returns>
    Task<IEnumerable<MessageModel>> GetMessagesAsync(
        GetMessagesParameters parameters,
        CancellationToken cancellationToken = default
    );
}
