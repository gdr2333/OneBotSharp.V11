using OneBotSharp.V11.Messages.Base;
using OneBotSharp.V11.Messages.Payload;

namespace OneBotSharp.V11.Messages;

/// <summary>
/// 群推荐消息段
/// </summary>
public class ContactGroupSegment : ContactSegmentBase
{
    /// <summary>
    /// 创建一个群推荐消息段
    /// </summary>
    /// <param name="contactId">要推荐的群号</param>
    public ContactGroupSegment(long contactId) : base("group", contactId)
    {
    }

    internal ContactGroupSegment(ContactPayload payload, JsonNode? payloadNode) : base(payload, payloadNode)
    {
    }
}
