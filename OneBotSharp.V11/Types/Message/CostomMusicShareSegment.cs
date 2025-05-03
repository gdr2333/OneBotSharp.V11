using OneBotSharp.V11.Types.Message.Base;
using OneBotSharp.V11.Types.Message.Payload;

namespace OneBotSharp.V11.Types.Message;

/// <summary>
/// 自定义音乐分享消息段
/// </summary>
public class CostomMusicShareSegment : MusicShareSegmentBase
{
    /// <inheritdoc/>
    [JsonIgnore]
    public override string MusicShareType => "costom";

    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 跳转到的URL
    /// </summary>
    [JsonIgnore]
    public Uri ToUrl { get; private init; }

    /// <summary>
    /// 音频URL
    /// </summary>
    [JsonIgnore]
    public Uri AudioUrl { get; private init; }

    /// <summary>
    /// 音乐分享标题
    /// </summary>
    [JsonIgnore]
    public string Title { get; private init; }

    /// <summary>
    /// 音乐分享描述
    /// </summary>
    [JsonIgnore]
    public string? Content { get; private init; }

    /// <summary>
    /// 图片URL
    /// </summary>
    [JsonIgnore]
    public Uri? ImageUrl { get; private init; }

    [JsonIgnore]
    private readonly JsonNode _payload;

    /// <summary>
    /// 构建一个新的
    /// </summary>
    /// <param name="toUrl">跳转到的URL</param>
    /// <param name="audioUrl">音频URL</param>
    /// <param name="title">音乐分享标题</param>
    /// <param name="content">音乐分享描述</param>
    /// <param name="imageUrl">图片URL</param>
    public CostomMusicShareSegment(Uri toUrl, Uri audioUrl, string title, string? content = null, Uri? imageUrl = null)
    {
        ToUrl = toUrl;
        AudioUrl = audioUrl;
        Title = title;
        Content = content;
        ImageUrl = imageUrl;
        var payload = new JsonObject()
        {
            { "url", toUrl.AbsoluteUri },
            { "audio", audioUrl.AbsoluteUri },
            { "title", title },
        };
        if (content is not null)
            payload.Add("content", content);
        if (imageUrl is not null)
            payload.Add("image", imageUrl.AbsoluteUri);
        _payload = payload;
    }

    internal CostomMusicShareSegment(CustomMusicSharePayload payload, JsonNode payloadNode)
    {
        ToUrl = payload.ToUrl;
        AudioUrl = payload.AudioUrl;
        Title = payload.Title;
        Content = payload.Content;
        ImageUrl = payload.ImageUrl;
        _payload = payloadNode;
    }
}
