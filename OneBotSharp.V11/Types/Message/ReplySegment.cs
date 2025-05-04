using OneBotSharp.V11.Types.Message.Base;
using OneBotSharp.V11.Types.Message.Payload;

namespace OneBotSharp.V11.Types.Message;

/// <summary>
/// 回复消息段
/// </summary>
public class ReplySegment : Segment
{
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("type")]
    public override string Type => "reply";

    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 要回复的消息ID
    /// </summary>
    [JsonIgnore]
    public long Id { get; internal init; }

    [JsonIgnore]
    private readonly JsonNode _payload;

    /// <summary>
    /// 创建一个回复消息段
    /// </summary>
    /// <param name="id">要回复的消息Id</param>
    public ReplySegment(long id)
    {
        Id = id;
        _payload = new JsonObject()
        {
            { "id", Id },
        };
    }

    internal ReplySegment(IdOnlyPayload payload, JsonNode? payloadNode)
    {
        Id = payload.Id;
        _payload = payloadNode ?? JsonValue.Create(payload) ?? throw new JsonException("JsonValue.Create出现内部错误");
    }
}
