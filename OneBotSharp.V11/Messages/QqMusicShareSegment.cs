using OneBotSharp.V11.Messages.Base;
using OneBotSharp.V11.Messages.Payload;

namespace OneBotSharp.V11.Messages;

/// <summary>
/// 预定义音乐分享消息段（QQ）
/// </summary>
public class QqMusicShareSegment : PredefinedMusicShareSegmentBase
{
    /// <summary>
    /// 构建一个QQ音乐的音乐分享消息段
    /// </summary>
    /// <param name="musicId">音乐ID</param>
    public QqMusicShareSegment(long musicId) : base("qq", musicId)
    {
    }

    internal QqMusicShareSegment(MusicSharePayload payload, JsonNode? payloadNode) : base(payload, payloadNode)
    {
    }
}
