using System.Xml;
using OneBotSharp.V11.Messages.Base;
using OneBotSharp.V11.Messages.Payload;

namespace OneBotSharp.V11.Messages;

/// <summary>
/// XML消息段
/// </summary>
public class XmlSegment : Segment
{
    /// <inheritdoc/>
    public override string Type => "xml";

    /// <inheritdoc/>
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 消息段的Data数据（XML）
    /// </summary>
    public XmlDocument Data { get; private init; }

    private readonly JsonNode _payload;

    /// <summary>
    /// 使用XML数据构建新的XML消息段
    /// </summary>
    /// <param name="data">XML数据</param>
    public XmlSegment(XmlDocument data)
    {
        Data = data;
        // 我知道这一点都不优雅，但我只会这么干。
        using StringWriter writer = new();
        using XmlTextWriter xmlWriter = new(writer);
        data.WriteTo(xmlWriter);
        xmlWriter.Flush();
        _payload = new JsonObject()
        {
            { "data", writer.ToString() }
        };
    }

    internal XmlSegment(DataOnlyPayload payload, JsonNode? payloadNode)
    {
        using StringReader reader = new(payload.Data);
        Data = new();
        Data.Load(reader);
        _payload = payloadNode ?? JsonValue.Create(payload) ?? throw new JsonException("JsonValue.Create出现内部错误");
    }
}
