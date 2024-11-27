using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LibreComm.Services.Messages.Domain.Entities;

/// <summary>
/// Message entity.
/// </summary>
public class Message
{
    /// <summary>
    /// ID.
    /// </summary>
    [BsonElement("_id")]
    [BsonId]
    public Guid Id { get; set; }

    /// <summary>
    /// Created at.
    /// </summary>
    [BsonElement("created_at")]
    public required DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Updated at.
    /// </summary>
    [BsonElement("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// Sender ID.
    /// </summary>
    [BsonElement("sender_id")]
    [BsonRequired]
    public required Guid SenderId { get; set; }

    /// <summary>
    /// Recipient ID.
    /// </summary>
    [BsonElement("recipient_id")]
    [BsonRequired]
    public required Guid RecipientId { get; set; }

    /// <summary>
    /// Content.
    /// </summary>
    [BsonElement("content")]
    [BsonRequired]
    public required string Content { get; set; }
}
