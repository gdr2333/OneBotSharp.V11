using OneBotSharp.V11.Types.Message.Base;
using OneBotSharp.V11.Types.Message.Payload;

namespace OneBotSharp.V11.Types.Message;

/// <summary>
/// Json消息段
/// </summary>
public class JsonSegment : Segment
{
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("type")]
    public override string Type => "json";

    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    /// <summary>
    /// JSON消息段内部的JSON数据
    /// </summary>
    public JsonNode Data { get; private init; }

    private readonly JsonNode _payload;

    /// <summary>
    /// 使用JSON数据创建一个JSON消息段
    /// </summary>
    /// <param name="data">JSON消息段内部的JSON数据</param>
    public JsonSegment(JsonNode data)
    {
        Data = data;
        _payload = new JsonObject()
        {
            { "data", Data.ToJsonString() }
        };
    }

    internal JsonSegment(DataOnlyPayload payload, JsonNode? payloadNode)
    {
        Data = JsonNode.Parse(payload.Data) ?? throw new JsonException("JSON解析失败！");
        _payload = payloadNode ?? JsonValue.Create(payload) ?? throw new JsonException("JsonValue.Create出现内部错误");
    }
}
