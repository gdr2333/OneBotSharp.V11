using OneBotSharp.V11.Messages.Base;
using OneBotSharp.V11.Messages.Payload;

namespace OneBotSharp.V11.Messages;

/// <summary>
/// 预定义音乐分享消息段（虾米）
/// </summary>
[Obsolete("这平台已经凉了。")]
public class XiamiMusicShareSegment : PredefinedMusicShareSegmentBase
{
    /// <summary>
    /// 构建一个虾米音乐的音乐分享消息段
    /// </summary>
    /// <param name="musicId">音乐ID</param>
    public XiamiMusicShareSegment(long musicId) : base("xm", musicId)
    {
    }

    internal XiamiMusicShareSegment(MusicSharePayload payload, JsonNode? payloadNode) : base(payload, payloadNode)
    {
    }
}
