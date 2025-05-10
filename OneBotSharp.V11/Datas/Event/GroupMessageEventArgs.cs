namespace OneBotSharp.V11.Datas.Event;

/// <summary>
/// 群聊消息事件参数
/// </summary>
public class GroupMessageEventArgs : MessageEventArgs
{
    /// <summary>
    /// 群ID
    /// </summary>
    public ulong Gid { get; private init; }

    /// <summary>
    /// 消息匿名信息（非匿名消息为null）
    /// </summary>
    public AnonymousData? Anonymous { get; private init; }

    /// <summary>
    /// 消息发送者信息
    /// </summary>
    public new GroupMessageSender Sender { get; private init; }

    internal GroupMessageEventArgs(JsonNode data) : base(data, data["sender"].GetValue<GroupMessageSender>())
    {
        Gid = data["group_id"].GetValue<ulong>();
        var anonymousData = data["anonymous"];
        if (anonymousData is null || anonymousData.GetValueKind() == JsonValueKind.Null)
            Anonymous = null;
        else
            Anonymous = anonymousData.GetValue<AnonymousData>();
        // 如果这里会出异常我就吃了它
        Sender = (GroupMessageSender)base.Sender;
    }
}
