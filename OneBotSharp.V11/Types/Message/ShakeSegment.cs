using OneBotSharp.V11.Types.Message.Base;

namespace OneBotSharp.V11.Types.Message;

/// <summary>
/// 窗口抖动（戳一戳）*消息段
/// <br/>
/// *：原文如此
/// </summary>
public class ShakeSegment : Segment
{
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("type")]
    public override string Type => "shake";

    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    [JsonIgnore]
    private readonly JsonNode _payload;

    /// <summary>
    /// 新建一个窗口抖动（戳一戳）*消息段
    /// <br/>
    /// *：原文如此
    /// </summary>
    public ShakeSegment() : this(new JsonObject())
    {
    }

    internal ShakeSegment(JsonNode payloadNode)
    {
        _payload = payloadNode;
    }
}
