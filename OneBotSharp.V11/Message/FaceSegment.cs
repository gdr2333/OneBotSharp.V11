using OneBotSharp.V11.Message.Base;
using OneBotSharp.V11.Message.Payload;

namespace OneBotSharp.V11.Message;

/// <summary>
/// 表情消息段
/// </summary>
public class FaceSegment : Segment
{
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("type")]
    public override string Type => "face";

    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 表情ID
    /// </summary>
    [JsonIgnore]
    public long Id { get; private init; }

    [JsonIgnore]
    private readonly JsonNode _payload;

    /// <summary>
    /// 创建一个指定ID的表情消息段
    /// </summary>
    /// <param name="id">表情ID</param>
    public FaceSegment(long id)
    {
        Id = id;
        _payload = new JsonObject()
        {
            { "id", Id }
        };
    }

    internal FaceSegment(IdOnlyPayload payload, JsonNode? payloadNode = null)
    {
        Id = payload.Id;
        _payload = payloadNode ?? JsonValue.Create(payload) ?? throw new JsonException("JsonValue.Create出现内部错误");
    }
}
