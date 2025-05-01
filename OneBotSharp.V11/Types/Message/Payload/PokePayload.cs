using OneBotSharp.V11.Types.Message.Base;
using OneBotSharp.V11.Utils.Converter;

namespace OneBotSharp.V11.Types.Message.Payload;

internal struct PokePayload : IPayload<PokePayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("type"), JsonConverter(typeof(CqIntConverter))]
    public int Type;

    [JsonInclude, JsonRequired, JsonPropertyName("id"), JsonConverter(typeof(CqIntConverter))]
    public int Id;

    [JsonInclude, JsonPropertyName("name")]
    public string? Name;

    public static PokePayload Create(CqCode code)
    {
        var res = new PokePayload
        {
            Type = int.Parse(code.Payload["type"], Defaults.DefaultFormat),
            Id = int.Parse(code.Payload["id"], Defaults.DefaultFormat)
        };
        if (code.Payload.TryGetValue("name", out var name))
            res.Name = name;
        else
            res.Name = null;
        return res;
    }
}
