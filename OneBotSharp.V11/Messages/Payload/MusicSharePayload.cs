using OneBotSharp.V11.Messages.Base;

namespace OneBotSharp.V11.Messages.Payload;

internal struct MusicSharePayload : IPayload<MusicSharePayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("type")]
    public string Type;

    [JsonInclude, JsonRequired, JsonPropertyName("id"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long Id;

    public static MusicSharePayload Create(CqCode code) =>
        new()
        {
            Type = code.Payload["type"],
            Id = long.Parse(code.Payload["id"], Defaults.DefaultFormat),
        };
}
