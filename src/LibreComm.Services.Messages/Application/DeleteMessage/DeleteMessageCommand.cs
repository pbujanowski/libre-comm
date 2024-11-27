using LibreComm.Services.Common.Application.Models;
using MediatR;

namespace LibreComm.Services.Messages.Application.DeleteMessage;

/// <summary>
/// DeleteMessage command.
/// </summary>
/// <param name="Message">Message.</param>
public record DeleteMessageCommand(DeleteMessageModel Message) : IRequest<DeleteMessageResult>;
