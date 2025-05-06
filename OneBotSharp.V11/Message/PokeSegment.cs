using OneBotSharp.V11.Message.Base;
using OneBotSharp.V11.Message.Payload;

namespace OneBotSharp.V11.Message;

/// <summary>
/// 戳一戳消息段
/// </summary>
public class PokeSegment : Segment
{
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("type")]
    public override string Type => "poke";

    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 戳一戳类型
    /// </summary>
    [JsonIgnore]
    public int PokeType { get; private init; }

    /// <summary>
    /// 戳一戳Id
    /// </summary>
    [JsonIgnore]
    public int PokeId { get; private init; }

    /// <summary>
    /// 戳一戳表情名
    /// </summary>
    [JsonIgnore]
    public string? Name { get; private init; }

    [JsonIgnore]
    private readonly JsonNode _payload;

    /// <summary>
    /// 新建一个戳一戳消息段
    /// </summary>
    /// <param name="type">戳一戳类型</param>
    /// <param name="id">戳一戳Id</param>
    public PokeSegment(int type, int id)
    {
        PokeType = type;
        PokeId = id;
        Name = null;
        _payload = new JsonObject()
        {
            { "type", PokeType },
            { "id", PokeId },
        };
    }

    internal PokeSegment(PokePayload payload, JsonNode? payloadNode)
    {
        PokeType = payload.Type;
        PokeId = payload.Id;
        Name = payload.Name;
        _payload = payloadNode ?? JsonValue.Create(payload) ?? throw new JsonException("JsonValue.Create出现内部错误");
    }
}
