using OneBotSharp.V11.Messages;

namespace OneBotSharp.V11.Datas.Event;

/// <summary>
/// 收到消息事件参数
/// </summary>
public class MessageEventArgs : PostEventArgs
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public string MessageType { get; protected init; }

    /// <summary>
    /// 消息子类型
    /// </summary>
    public string MessageSubType { get; protected init; }

    /// <summary>
    /// 消息ID
    /// </summary>
    public long MessageId { get; protected init; }

    /// <summary>
    /// 发送者ID
    /// </summary>
    public long Uid { get; protected init; }
    
    /// <summary>
    /// 消息内容
    /// </summary>
    public Message Message { get; protected init; }

    /// <summary>
    /// 原始消息
    /// </summary>
    public string RawMessage { get; protected init; }

    /// <summary>
    /// 字体编号
    /// </summary>
    public int Font { get; protected init; }

    /// <summary>
    /// 发送者信息
    /// </summary>
    public MessageSender Sender { get; protected init; }

    internal MessageEventArgs(JsonNode data, MessageSender? sender = null) : base("message", data)
    {
        MessageType = data["message_type"].GetValue<string>();
        MessageSubType = data["sub_type"].GetValue<string>();
        MessageId = data["message_id"].GetValue<long>();
        Uid = data["user_id"].GetValue<long>();
        Message = new Message(data["message"]);
        RawMessage = data["raw_message"].GetValue<string>();
        Font = data["font"].GetValue<int>();
        Sender = sender ?? data["sender"].GetValue<MessageSender>();
    }
}
