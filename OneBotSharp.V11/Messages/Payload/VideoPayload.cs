using OneBotSharp.V11.Messages.Base;
using OneBotSharp.V11.Utils.Converter;

namespace OneBotSharp.V11.Messages.Payload;

[method: JsonConstructor]
internal struct VideoPayload() : IPayload<VideoPayload>
{
    // 要不是因为struct不能继承我高低要做个internal struct FilePayloadBase出来
    [JsonInclude, JsonRequired, JsonPropertyName("file")]
    public string File;

    [JsonInclude, JsonPropertyName("url")]
    public Uri? Url;

    [JsonInclude, JsonPropertyName("cache"), JsonConverter(typeof(CqBoolConverter))]
    public bool UseCache = Defaults.CqUseCacheDefault;

    [JsonInclude, JsonPropertyName("proxy"), JsonConverter(typeof(CqBoolConverter))]
    public bool UseProxy = Defaults.CqUseProxyDefault;

    [JsonInclude, JsonPropertyName("timeout"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int? TimeOut = null;

    public static VideoPayload Create(CqCode code) =>
        new()
        {
            File = code.Payload["file"],
            Url = code.Payload.TryGetValue("url", out var url) ? new(url) : null
        };
}
