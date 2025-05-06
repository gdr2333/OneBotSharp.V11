using OneBotSharp.V11.Message.Base;

namespace OneBotSharp.V11.Message;

/// <summary>
/// 猜拳魔法表情*消息段
/// <br/>
/// *：原文如此
/// </summary>
public class RpsSegment : Segment
{
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("type")]
    public override string Type => "rps";

    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    [JsonIgnore]
    private readonly JsonNode _payload;

    /// <summary>
    /// 新建一个猜拳魔法表情*消息段
    /// <br/>
    /// *：原文如此
    /// </summary>
    public RpsSegment() : this(new JsonObject())
    {
    }

    internal RpsSegment(JsonNode? payloadNode)
    {
        _payload = payloadNode ?? new JsonObject();
    }
}
