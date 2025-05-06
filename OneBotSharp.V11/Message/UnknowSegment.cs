using OneBotSharp.V11.Message.Base;

namespace OneBotSharp.V11.Message;

/// <summary>
/// 未知消息段
/// <br/>
/// 理论上来说你可以用这个类发任何消息段（包括已经做好的），但是请<strong>不要</strong>这么做！
/// </summary>
public class UnknowSegment : Segment
{
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("type")]
    public override string Type => _type;

    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    [JsonIgnore]
    private readonly string _type;

    [JsonIgnore]
    private readonly JsonNode _payload;

    /// <summary>
    /// 构建一个未知消息段
    /// </summary>
    /// <param name="type">消息段类型</param>
    /// <param name="payload">消息段data内容（JSON）</param>
    public UnknowSegment(string type, JsonNode payload)
    {
        _type = type;
        _payload = payload;
    }

    internal UnknowSegment(CqCode code)
    {
        _type = code.Type;
        var payload = new JsonObject();
        foreach(var i in code.Payload)
            payload.Add(i.Key, i.Value);
        _payload = payload;
    }
}
