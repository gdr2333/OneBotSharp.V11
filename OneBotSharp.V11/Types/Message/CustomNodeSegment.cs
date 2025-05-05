using OneBotSharp.V11.Types.Message.Base;
using OneBotSharp.V11.Types.Message.Payload;

namespace OneBotSharp.V11.Types.Message;

/// <summary>
/// 自定义转发消息节点类
/// </summary>
public class CustomNodeSegment : NodeSegmentBase
{
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 消息发送者UID
    /// </summary>
    [JsonIgnore]
    public long SenderUid { get; private init; }

    /// <summary>
    /// 消息发送者昵称
    /// </summary>
    [JsonIgnore]
    public string SenderNickname { get; private init; }

    /// <summary>
    /// 转发的消息
    /// </summary>
    [JsonIgnore]
    public Message Message { get; private init; }

    [JsonIgnore]
    private readonly JsonNode _payload;

    /// <summary>
    /// 使用指定消息构建一个自定义转发消息节点
    /// </summary>
    /// <param name="senderUid">发送者UID</param>
    /// <param name="senderNickname">消息发送者昵称</param>
    /// <param name="message">转发的消息</param>
    public CustomNodeSegment(long senderUid, string senderNickname, Message message)
    {
        SenderUid = senderUid;
        SenderNickname = senderNickname;
        Message = message;
        _payload = new JsonObject()
        {
            { "user_id", senderUid },
            { "nickname", senderNickname },
            { "content", message.ToJson() }
        };
    }

    internal CustomNodeSegment(CustomNodePayload payload, JsonNode? payloadNode)
    {
        SenderUid = payload.Uid;
        SenderNickname = payload.Nickname;
        Message = new Message(payload.Content);
        _payload = payloadNode ?? JsonValue.Create(payload) ?? throw new JsonException("JsonValue.Create出现内部错误");
    }
}
