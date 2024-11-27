using LibreComm.Services.Common.Application.Models;

namespace LibreComm.Services.Messages.Application.Queries.GetMessages;

/// <summary>
/// GetMessages result.
/// </summary>
/// <param name="Messages">Messages.</param>
public record GetMessagesResult(IEnumerable<MessageModel> Messages);
