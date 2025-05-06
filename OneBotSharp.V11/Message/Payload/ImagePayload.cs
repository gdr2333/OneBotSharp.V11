using OneBotSharp.V11.Message.Base;
using OneBotSharp.V11.Utils.Converter;

namespace OneBotSharp.V11.Message.Payload;

[method: JsonConstructor]
internal struct ImagePayload() : IPayload<ImagePayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("file")]
    public string File;

    [JsonInclude, JsonPropertyName("type")]
    public string? ImageType = null;

    [JsonInclude, JsonPropertyName("url")]
    public Uri? Url;

    [JsonInclude, JsonPropertyName("cache"), JsonConverter(typeof(CqBoolConverter))]
    public bool UseCache = Defaults.CqUseCacheDefault;

    [JsonInclude, JsonPropertyName("proxy"), JsonConverter(typeof(CqBoolConverter))]
    public bool UseProxy = Defaults.CqUseProxyDefault;

    [JsonInclude, JsonPropertyName("timeout"), JsonConverter(typeof(CqIntConverter))]
    public int? TimeOut = null;

    public static ImagePayload Create(CqCode code) =>
        new()
        {
            File = code.Payload["file"],
            ImageType = code.Payload.TryGetValue("type", out var typ) ? typ : null,
            Url = code.Payload.TryGetValue("url", out var url) ? new(url) : null
        };
}
