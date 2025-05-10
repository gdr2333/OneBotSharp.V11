namespace OneBotSharp.V11.Datas.Event;

/// <summary>
/// 上报消息数据基类
/// </summary>
public abstract class PostEventArgs : EventArgs
{
    /// <summary>
    /// 上报时间
    /// </summary>
    public DateTime Time { get; protected set; }

    /// <summary>
    /// 机器人Uid
    /// </summary>
    public ulong BotUid { get; protected set; }

    /// <summary>
    /// 消息类型
    /// </summary>
    public string Type { get; protected set; }

    internal PostEventArgs(string type, JsonNode data)
    {
        Time = MiscUtils.FromUnixTime(data["time"].GetValue<ulong>());
        BotUid = data["self_id"].GetValue<ulong>();
        Type = type;
    }

    internal PostEventArgs AutoInit(JsonNode data)
    {
#warning NOT DONE!
        throw new NotImplementedException();
    }
}
