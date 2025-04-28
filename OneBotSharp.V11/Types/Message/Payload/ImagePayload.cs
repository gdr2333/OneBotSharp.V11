using OneBotSharp.V11.Types.Message.Base;
using OneBotSharp.V11.Utils.Converter;

namespace OneBotSharp.V11.Types.Message.Payload;

internal struct ImagePayload : IPayload<ImagePayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("file")]
    public string File;

    [JsonInclude, JsonPropertyName("type")]
    public string? ImageType;

    [JsonInclude, JsonPropertyName("url")]
    public Uri? Url;

    [JsonInclude, JsonConverter(typeof(CqBoolConverter))]
    public bool UseCache;

    [JsonInclude, JsonConverter(typeof(CqBoolConverter))]
    public bool UseProxy;

    [JsonInclude, JsonConverter(typeof(CqIntConverter))]
    public int? TimeOut;

    [JsonConstructor]
    public ImagePayload()
    {
        ImageType = null;
        UseCache = Defaults.CqUseCacheDefault;
        UseProxy = Defaults.CqUseProxyDefault;
        TimeOut = null;
    }

    public static ImagePayload Create(CqCode code) =>
        new()
        {
            File = code.Payload["file"],
            ImageType = code.Payload.TryGetValue("type", out var typ) ? typ : null,
            Url = code.Payload.TryGetValue("url", out var url) ? new(url) : null
        };
}
