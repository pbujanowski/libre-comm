namespace LibreComm.Services.Common.Application.Models;

/// <summary>
/// CreateMessage model.
/// </summary>
/// <param name="SenderId">Sender ID.</param>
/// <param name="RecipientId">Recipient ID.</param>
/// <param name="Content">Content.</param>
public record CreateMessageModel(Guid SenderId, Guid RecipientId, string Content);
