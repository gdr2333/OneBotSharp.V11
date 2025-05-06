using OneBotSharp.V11.Message.Base;

namespace OneBotSharp.V11.Message.Payload;

internal struct CustomMusicSharePayload : IPayload<CustomMusicSharePayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("type")]
    public string Type;

    [JsonInclude, JsonRequired, JsonPropertyName("url")]
    public Uri ToUrl;

    [JsonInclude, JsonRequired, JsonPropertyName("audio")]
    public Uri AudioUrl;

    [JsonInclude, JsonRequired, JsonPropertyName("title")]
    public string Title;

    [JsonInclude, JsonPropertyName("content")]
    public string? Content;

    [JsonInclude, JsonPropertyName("image")]
    public Uri? ImageUrl;

    public static CustomMusicSharePayload Create(CqCode code) =>
        new()
        {
            Type = code.Payload["type"],
            ToUrl = new(code.Payload["url"]),
            AudioUrl = new(code.Payload["audio"]),
            Title = code.Payload["title"],
            Content = code.Payload.TryGetValue("content", out var content) ? content : null,
            ImageUrl = code.Payload.TryGetValue("image", out var image) ? new(image) : null,
        };
}
