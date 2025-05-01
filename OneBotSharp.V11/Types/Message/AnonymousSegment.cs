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
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 是否在无法匿名时继续发送
    /// </summary>
    public bool Ignore { get; private init; }

    private JsonNode _payload;

    /// <summary>
    /// 新建一个匿名消息段
    /// </summary>
    public AnonymousSegment(bool ignore)
    {
        Ignore = ignore;
        _payload = new JsonObject()
        {
            {"ignore", CqCodeUtil.CqBoolEncoode(Ignore)}
        };
    }

    internal AnonymousSegment()
    {
        _payload = new JsonObject();
        Ignore = false;
    }
}
