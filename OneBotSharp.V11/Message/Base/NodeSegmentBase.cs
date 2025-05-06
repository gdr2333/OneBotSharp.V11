namespace OneBotSharp.V11.Message.Base;

/// <summary>
/// 转发节点基类
/// </summary>
public abstract class NodeSegmentBase : Segment
{
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("type")]
    public override string Type => "node";
}
