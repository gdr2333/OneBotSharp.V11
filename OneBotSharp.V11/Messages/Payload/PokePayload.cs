using OneBotSharp.V11.Messages.Base;

namespace OneBotSharp.V11.Messages.Payload;

internal struct PokePayload : IPayload<PokePayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("type"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int Type;

    [JsonInclude, JsonRequired, JsonPropertyName("id"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int Id;

    [JsonInclude, JsonPropertyName("name")]
    public string? Name;

    public static PokePayload Create(CqCode code) =>
        new()
        {
            Type = int.Parse(code.Payload["type"], Defaults.DefaultFormat),
            Id = int.Parse(code.Payload["id"], Defaults.DefaultFormat),
            Name = code.Payload.TryGetValue("name", out var name) ? name : null
        };
}
