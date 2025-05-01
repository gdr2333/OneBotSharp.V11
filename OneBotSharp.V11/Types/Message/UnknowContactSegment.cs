using OneBotSharp.V11.Types.Message.Base;
using OneBotSharp.V11.Types.Message.Payload;

namespace OneBotSharp.V11.Types.Message;

/// <summary>
/// 未知推荐消息段
/// </summary>
public class UnknowContactSegment : ContactSegmentBase
{
    /// <summary>
    /// 构建一个未知推荐消息段
    /// </summary>
    /// <param name="contactType">推荐类型</param>
    /// <param name="contactId">推荐ID</param>
    public UnknowContactSegment(string contactType, long contactId) : base(contactType, contactId)
    {
    }

    internal UnknowContactSegment(ContactPayload payload, JsonNode payloadNode) : base(payload, payloadNode)
    {
    }
}
