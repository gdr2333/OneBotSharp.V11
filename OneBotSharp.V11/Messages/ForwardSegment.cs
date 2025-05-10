using OneBotSharp.V11.Messages.Base;
using OneBotSharp.V11.Messages.Payload;

namespace OneBotSharp.V11.Messages;

/// <summary>
/// 合并转发消息段
/// </summary>
public class ForwardSegment : Segment
{
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("type")]
    public override string Type => "forward";

    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 合并转发ID
    /// </summary>
    [JsonIgnore]
    public long ForwardId { get; private init; }

    [JsonIgnore]
    private readonly JsonNode _payload;

    internal ForwardSegment(IdOnlyPayload payload, JsonNode? payloadNode)
    {
        ForwardId = payload.Id;
        _payload = payloadNode ?? JsonValue.Create(payload) ?? throw new JsonException("JsonValue.Create出现内部错误");
    }
}
