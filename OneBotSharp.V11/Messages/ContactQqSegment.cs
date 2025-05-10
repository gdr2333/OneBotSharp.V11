using OneBotSharp.V11.Messages.Base;
using OneBotSharp.V11.Messages.Payload;

namespace OneBotSharp.V11.Messages;

/// <summary>
/// QQ推荐消息段
/// </summary>
public class ContactQqSegment : ContactSegmentBase
{
    /// <summary>
    /// 创建一个QQ推荐消息段
    /// </summary>
    /// <param name="contactId">要推荐的QQ号</param>
    public ContactQqSegment(long contactId) : base("qq", contactId)
    {
    }

    internal ContactQqSegment(ContactPayload payload, JsonNode? payloadNode) : base(payload, payloadNode)
    {
    }
}
