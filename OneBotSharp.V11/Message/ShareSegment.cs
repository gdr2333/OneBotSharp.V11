using OneBotSharp.V11.Message.Base;
using OneBotSharp.V11.Message.Payload;

namespace OneBotSharp.V11.Message;

/// <summary>
/// 连接分享消息段
/// </summary>
public class ShareSegment : Segment
{
    /// <inheritdoc/>
    public override string Type => "share";

    /// <inheritdoc/>
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 要跳转到的URL
    /// </summary>
    public Uri Url { get; private init; }

    /// <summary>
    /// 分享标题
    /// </summary>
    public string Title { get; private init; }

    /// <summary>
    /// （可选）描述
    /// </summary>
    public string? Content { get; private init; }

    /// <summary>
    /// （可选）分享图片URL
    /// </summary>
    public Uri? ImageUrl { get; private init; }

    private readonly JsonNode _payload;

    /// <summary>
    /// 新建一个连接分享消息段
    /// </summary>
    /// <param name="url">要跳转到的URL</param>
    /// <param name="title">分享标题</param>
    /// <param name="content">（可选）描述</param>
    /// <param name="imageUrl">（可选）分享图片URL</param>
    public ShareSegment(Uri url, string title, string? content = null, Uri? imageUrl = null)
    {
        Url = url;
        Title = title;
        Content = content;
        ImageUrl = imageUrl;
        var payload = new JsonObject()
        {
            {"url", url.AbsoluteUri },
            {"title", title}
        };
        if(content is not null)
            payload.Add("content", content);
        if (imageUrl is not null)
            payload.Add("image", imageUrl.AbsoluteUri);
        _payload = payload;
    }

    internal ShareSegment(SharePayload payload, JsonNode? payloadNode)
    {
        Url = payload.Url;
        Title = payload.Title;
        Content = payload.Content;
        ImageUrl = payload.ImageUrl;
        _payload = payloadNode ?? JsonValue.Create(payload) ?? throw new JsonException("JsonValue.Create出现内部错误");
    }
}
