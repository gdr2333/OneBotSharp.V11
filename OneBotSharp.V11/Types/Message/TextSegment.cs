using OneBotSharp.V11.Types.Message.Base;
using OneBotSharp.V11.Types.Message.Payload;

namespace OneBotSharp.V11.Types.Message;

/// <summary>
/// 文本消息段
/// </summary>
public class TextSegment : Segment
{
    /// <inheritdoc/>
    public override string Type => "text";

    /// <inheritdoc/>
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 消息文本
    /// </summary>
    public string Text { get; private init; }

    private readonly JsonNode _payload;

    /// <summary>
    /// 创建一个包含指定文本的消息段
    /// </summary>
    /// <param name="text">消息段内容</param>
    public TextSegment(string text)
    {
        Text = text;
        _payload = new JsonObject()
        {
            { "text", Text }
        };
    }

    internal TextSegment(TextPayload payload, JsonNode? payloadNode = null)
    {
        Text = payload.Text;
        _payload = payloadNode ?? JsonValue.Create(payload) ?? throw new JsonException("JsonValue.Create出现内部错误");
    }
}
