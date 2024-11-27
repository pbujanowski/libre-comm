using LibreComm.Services.Common.Application.Models;
using MediatR;

namespace LibreComm.Services.Messages.Application.Queries.GetMessages;

/// <summary>
/// GetMessages query.
/// </summary>
/// <param name="Parameters">Parameters.</param>
public record GetMessagesQuery(GetMessagesParameters Parameters) : IRequest<GetMessagesResult>;
