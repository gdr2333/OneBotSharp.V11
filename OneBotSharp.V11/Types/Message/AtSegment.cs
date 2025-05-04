using OneBotSharp.V11.Types.Message.Base;
using OneBotSharp.V11.Types.Message.Payload;

namespace OneBotSharp.V11.Types.Message;

/// <summary>
/// at消息段
/// </summary>
public class AtSegment : Segment
{
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("type")]
    public override string Type => "at";

    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 要at的用户ID，在@所有人时可以为空
    /// </summary>
    [JsonIgnore]
    public long? Uid { get; private init; }

    /// <summary>
    /// 是否是@所有人
    /// </summary>
    [JsonIgnore]
    public bool AtAll { get; private init; }

    [JsonIgnore]
    private readonly JsonNode _payload;

    /// <summary>
    /// 创建一个at指定用户的at消息段
    /// </summary>
    /// <param name="uid">用户ID</param>
    public AtSegment(long uid)
    {
        Uid = uid;
        AtAll = false;
        _payload = new JsonObject()
        {
            {"qq", uid}
        };
    }

    /// <summary>
    /// 创建一个@所有人的at消息段
    /// </summary>
    public AtSegment()
    {
        Uid = null;
        AtAll = true;
        _payload = new JsonObject()
        {
            {"qq", "all" }
        };
    }

    internal AtSegment(AtPayload payload, JsonNode? payloadNode)
    {
        if (payload.QQ == "all")
        {
            AtAll = true;
            Uid = null;
        }
        else
        {
            AtAll = false;
            Uid = long.Parse(payload.QQ, Defaults.DefaultFormat);
        }
        _payload = payloadNode ?? JsonValue.Create(payload) ?? throw new JsonException("JsonValue.Create出现内部错误");
    }
}
