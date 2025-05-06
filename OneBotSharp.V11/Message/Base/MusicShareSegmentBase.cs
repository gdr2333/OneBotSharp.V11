namespace OneBotSharp.V11.Message.Base;

/// <summary>
/// 音乐分享基类
/// </summary>
public abstract class MusicShareSegmentBase : Segment
{
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("type")]
    public override string Type => "music";

    /// <summary>
    /// 音乐分享类型
    /// </summary>
    [JsonIgnore]
    public abstract string MusicShareType { get; }
}
