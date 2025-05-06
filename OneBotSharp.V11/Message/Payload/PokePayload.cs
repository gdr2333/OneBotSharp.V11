using OneBotSharp.V11.Message.Base;
using OneBotSharp.V11.Utils.Converter;

namespace OneBotSharp.V11.Message.Payload;

internal struct PokePayload : IPayload<PokePayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("type"), JsonConverter(typeof(CqIntConverter))]
    public int Type;

    [JsonInclude, JsonRequired, JsonPropertyName("id"), JsonConverter(typeof(CqIntConverter))]
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
