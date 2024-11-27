namespace LibreComm.Services.Common.Application.Models;

/// <summary>
/// Message model.
/// </summary>
/// <param name="Id">ID.</param>
/// <param name="CreatedAt">Created at.</param>
/// <param name="UpdatedAt">Updated at.</param>
/// <param name="SenderId">Sender ID.</param>
/// <param name="RecipientId">Recipient ID.</param>
/// <param name="Content">Content.</param>
public record MessageModel(
    Guid Id,
    DateTimeOffset CreatedAt,
    DateTimeOffset? UpdatedAt,
    Guid SenderId,
    Guid RecipientId,
    string Content
);
