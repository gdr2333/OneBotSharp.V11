using OneBotSharp.V11.Message.Base;

namespace OneBotSharp.V11.Message;

/// <summary>
/// 合并转发节点
/// </summary>
public class NodeSegment : NodeSegmentBase
{
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 要转发的消息Id
    /// </summary>
    [JsonIgnore]
    public long MessageId { get; private init; }

    [JsonIgnore]
    private readonly JsonNode _payload;

    /// <summary>
    /// 创建一个合并转发节点
    /// </summary>
    /// <param name="messageId">要转发的消息Id</param>
    public NodeSegment(long messageId)
    {
        MessageId = messageId;
        _payload = new JsonObject()
        {
            { "id", messageId }
        };
    }
}
