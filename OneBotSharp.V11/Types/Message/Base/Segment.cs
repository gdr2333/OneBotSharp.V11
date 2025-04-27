namespace OneBotSharp.V11.Types.Message.Base;

/// <summary>
/// 消息段基类
/// </summary>
public abstract class Segment
{
    /// <summary>
    /// 消息段类型
    /// </summary>
    public abstract string Type { get; }

    /// <summary>
    /// 消息段data内容（JSON）
    /// </summary>
    public abstract JsonNode Payload { get; }
}
