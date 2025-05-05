using OneBotSharp.V11.Types.Message.Base;

namespace OneBotSharp.V11.Types.Message;

/// <summary>
/// 消息类
/// </summary>
public class Message
{
    /// <summary>
    /// 消息内部的消息段
    /// </summary>
    public Segment[] Segments { get; private init; }

    /// <summary>
    /// 使用指定消息段数组构建一条消息
    /// </summary>
    /// <param name="segments">消息段数组</param>
    public Message(Segment[] segments)
    {
        Segments = segments;
    }

    /// <summary>
    /// 使用指定消息段构建一条消息
    /// </summary>
    /// <param name="seg">消息段</param>
    public Message(Segment seg)
    {
        Segments = [seg];
    }

    /// <summary>
    /// 从message消息节点构建一条消息
    /// </summary>
    /// <param name="node">消息节点</param>
    public Message(JsonNode node)
    {
        switch (node.GetValueKind())
        {
            case JsonValueKind.Object:
                Segments = [Segment.AutoInit(node)];
                break;
            case JsonValueKind.Array:
                var arr = node.AsArray();
                Segments = new Segment[arr.Count];
                for (int i = 0; i < Segments.Length; i++)
                    Segments[i] = Segment.AutoInit(arr[i]);
                break;
            case JsonValueKind.String:
                var cqCode = node.GetValue<string>();
                if (cqCode.Contains('[') && cqCode.Contains(']'))
                {
                    // 手搓解析器，启动！
                    var pos = 0;
                    var nowReadingCqcode = cqCode[pos] == '[';
                    var nxt = cqCode.IndexOf(nowReadingCqcode ? ']' : '[', pos);
                    var res = new List<Segment>();
                    while (nxt != -1 && nxt + Convert.ToInt32(nowReadingCqcode) < cqCode.Length)
                    {
                        nxt += Convert.ToInt32(nowReadingCqcode);
                        res.Add(Segment.AutoInit(CqCodeUtil.CqCodeDecode(cqCode[pos..nxt])));
                        pos = nxt;
                        nowReadingCqcode = cqCode[pos] == '[';
                        nxt = cqCode.IndexOf(nowReadingCqcode ? ']' : '[', pos);
                    }
                    Segments = [.. res, Segment.AutoInit(CqCodeUtil.CqCodeDecode(cqCode[pos..]))];
                }
                else
                    Segments = [new TextSegment(CqCodeUtil.CqCodeTextDecode(cqCode))];
                break;
            default:
                throw new ArgumentException("无效的JSON节点！");
        }
    }

    /// <summary>
    /// 从CQ码构建一条消息
    /// </summary>
    /// <param name="cqCode">CQ码</param>
    public Message(string cqCode)
    {
        if (cqCode.Contains('[') && cqCode.Contains(']'))
        {
            // 手搓解析器，启动！
            var pos = 0;
            var nowReadingCqcode = cqCode[pos] == '[';
            var nxt = cqCode.IndexOf(nowReadingCqcode ? ']' : '[', pos);
            var res = new List<Segment>();
            while (nxt != -1 && nxt + Convert.ToInt32(nowReadingCqcode) < cqCode.Length)
            {
                nxt += Convert.ToInt32(nowReadingCqcode);
                res.Add(Segment.AutoInit(CqCodeUtil.CqCodeDecode(cqCode[pos..nxt])));
                pos = nxt;
                nowReadingCqcode = cqCode[pos] == '[';
                nxt = cqCode.IndexOf(nowReadingCqcode ? ']' : '[', pos);
            }
            Segments = [.. res, Segment.AutoInit(CqCodeUtil.CqCodeDecode(cqCode[pos..]))];
        }
        else
            Segments = [new TextSegment(CqCodeUtil.CqCodeTextDecode(cqCode))];
    }

    /// <summary>
    /// 将消息转换为JSON消息数组
    /// </summary>
    /// <returns>JSON节点</returns>
    public JsonArray ToJson() =>
        [.. Array.ConvertAll(Segments, s => JsonValue.Create(s))];
}
