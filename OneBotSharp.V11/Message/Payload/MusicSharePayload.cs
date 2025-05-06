using OneBotSharp.V11.Message.Base;
using OneBotSharp.V11.Utils.Converter;

namespace OneBotSharp.V11.Message.Payload;

internal struct MusicSharePayload : IPayload<MusicSharePayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("type")]
    public string Type;

    [JsonInclude, JsonRequired, JsonPropertyName("id"), JsonConverter(typeof(CqLongConverter))]
    public long Id;

    public static MusicSharePayload Create(CqCode code) =>
        new()
        {
            Type = code.Payload["type"],
            Id = long.Parse(code.Payload["id"], Defaults.DefaultFormat),
        };
}
