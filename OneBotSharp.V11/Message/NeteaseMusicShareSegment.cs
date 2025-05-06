using OneBotSharp.V11.Message.Base;
using OneBotSharp.V11.Message.Payload;

namespace OneBotSharp.V11.Message;

/// <summary>
/// 预定义音乐分享消息段（163）
/// </summary>
public class NeteaseMusicShareSegment : PredefinedMusicShareSegmentBase
{
    /// <summary>
    /// 构建一个网易音乐的音乐分享消息段
    /// </summary>
    /// <param name="musicId">音乐ID</param>
    public NeteaseMusicShareSegment(long musicId) : base("163", musicId)
    {
    }

    internal NeteaseMusicShareSegment(MusicSharePayload payload, JsonNode? payloadNode) : base(payload, payloadNode)
    {
    }
}
