using OneBotSharp.V11.Message.Base;
using OneBotSharp.V11.Message.Payload;

namespace OneBotSharp.V11.Message;

/// <summary>
/// 未知音乐分享消息段
/// <br/>
/// 其实你在musicType里写qq也可以的
/// </summary>
public class UnknowMusicShareSegment : PredefinedMusicShareSegmentBase
{
    /// <summary>
    /// 构建一个未知音乐分享消息段
    /// </summary>
    /// <param name="musicShareType">平台</param>
    /// <param name="musicId">音乐ID</param>
    public UnknowMusicShareSegment(string musicShareType, long musicId) : base(musicShareType, musicId)
    {
    }

    internal UnknowMusicShareSegment(MusicSharePayload payload, JsonNode? payloadNode) : base(payload, payloadNode)
    {
    }
}
