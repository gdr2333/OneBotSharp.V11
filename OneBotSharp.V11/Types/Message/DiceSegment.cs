using OneBotSharp.V11.Types.Message.Base;

namespace OneBotSharp.V11.Types.Message;

/// <summary>
/// 掷骰子魔法表情*消息段
/// <br/>
/// *：原文如此
/// </summary>
public class DiceSegment : Segment
{
    // 如果你觉得这玩意跟Rps那个消息段基本一样，你是对的......复制粘贴+查找替换就完了，还有下面那个shake也一样，别问我为什么，我不知道......
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("type")]
    public override string Type => "dice";

    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    [JsonIgnore]
    private readonly JsonNode _payload;

    /// <summary>
    /// 新建一个掷骰子魔法表情*消息段
    /// <br/>
    /// *：原文如此
    /// </summary>
    public DiceSegment() : this(new JsonObject())
    {
    }

    internal DiceSegment(JsonNode? payloadNode)
    {
        _payload = payloadNode ?? new JsonObject();
    }
}
