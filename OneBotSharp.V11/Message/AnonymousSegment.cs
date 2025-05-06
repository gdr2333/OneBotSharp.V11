using OneBotSharp.V11.Message.Base;

namespace OneBotSharp.V11.Message;

/// <summary>
/// 匿名消息段
/// </summary>
public class AnonymousSegment : Segment
{
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

    private readonly JsonNode _payload;

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
