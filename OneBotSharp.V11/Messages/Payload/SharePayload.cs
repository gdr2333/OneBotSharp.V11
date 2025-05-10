using OneBotSharp.V11.Messages.Base;

namespace OneBotSharp.V11.Messages.Payload;

internal struct SharePayload : IPayload<SharePayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("url")]
    public Uri Url;

    [JsonInclude, JsonRequired, JsonPropertyName("title")]
    public string Title;

    [JsonInclude, JsonPropertyName("content")]
    public string? Content;

    [JsonInclude, JsonPropertyName("image")]
    public Uri? ImageUrl;

    public static SharePayload Create(CqCode code) =>
        new()
        {
            Url = new(code.Payload["url"]),
            Title = code.Payload["title"],
            Content = code.Payload.TryGetValue("content", out var content) ? content : null,
            ImageUrl = code.Payload.TryGetValue("image", out var image) ? new(image) : null
        };
}
