using OneBotSharp.V11.Types.Message.Payload;

namespace OneBotSharp.V11.Types.Message.Base;

// 你问我为啥要abstract？因为我不想让一个消息段继承自另一个消息段，就这样。
/// <summary>
/// 各种推荐消息段的基类
/// </summary>
public abstract class ContactSegmentBase : Segment
{
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("type")]
    public override string Type => "contact";

    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 推荐类型
    /// </summary>
    [JsonIgnore]
    public string ContactType { get; protected init; }

    /// <summary>
    /// 要推荐的ID
    /// </summary>
    [JsonIgnore]
    public long ContactId { get; protected set; }

    [JsonIgnore]
    private readonly JsonNode _payload;

    /// <summary>
    /// 构建推荐消息段（仅用于继承）
    /// </summary>
    /// <param name="contactType">推荐类型</param>
    /// <param name="contactId">要推荐的ID</param>
    public ContactSegmentBase(string contactType, long contactId)
    {
        ContactType = contactType;
        ContactId = contactId;
        _payload = new JsonObject()
        {
            { "type", contactType },
            { "id", contactId }
        };
    }

    internal ContactSegmentBase(ContactPayload payload, JsonNode payloadNode)
    {
        ContactType = payload.Type;
        ContactId = payload.Id;
        _payload = payloadNode;
    }
}
