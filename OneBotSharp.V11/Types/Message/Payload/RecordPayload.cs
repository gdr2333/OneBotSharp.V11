using OneBotSharp.V11.Types.Message.Base;
using OneBotSharp.V11.Utils.Converter;

namespace OneBotSharp.V11.Types.Message.Payload;

[method: JsonConstructor]
internal struct RecordPayload() : IPayload<RecordPayload>
{
    // 基本就是从ImagePayload改的，也许我该写个FilePayload的抽象？
    [JsonInclude, JsonRequired, JsonPropertyName("file")]
    public string File;

    [JsonInclude, JsonPropertyName("magic"), JsonConverter(typeof(CqBoolConverter))]
    public bool UseMagic = false;

    [JsonInclude, JsonPropertyName("url")]
    public Uri? Url;

    [JsonInclude, JsonConverter(typeof(CqBoolConverter))]
    public bool UseCache = Defaults.CqUseCacheDefault;

    [JsonInclude, JsonConverter(typeof(CqBoolConverter))]
    public bool UseProxy = Defaults.CqUseProxyDefault;

    [JsonInclude, JsonConverter(typeof(CqIntConverter))]
    public int? TimeOut = null;

    public static RecordPayload Create(CqCode code) =>
        new()
        {
            File = code.Payload["file"],
            UseMagic = code.Payload.TryGetValue("magic", out var typ) && CqCodeUtil.CqBoolDecode(typ),
            Url = code.Payload.TryGetValue("url", out var url) ? new(url) : null
        };
}
