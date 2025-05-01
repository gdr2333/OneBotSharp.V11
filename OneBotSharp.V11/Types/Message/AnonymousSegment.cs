using OneBotSharp.V11.Types.Message.Base;

namespace OneBotSharp.V11.Types.Message;

/// <summary>
/// 匿名消息段
/// </summary>
public class AnonymousSegment : Segment
{
    // 因为收不到这下连个内部的payload都无了
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("type")]
    public override string Type => "anonymous";

    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => new JsonObject();

    /// <summary>
    /// 新建一个匿名消息段
    /// </summary>
    public AnonymousSegment() 
    {
    }
}
