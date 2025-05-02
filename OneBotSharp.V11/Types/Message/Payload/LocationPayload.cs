using OneBotSharp.V11.Types.Message.Base;
using OneBotSharp.V11.Utils.Converter;

namespace OneBotSharp.V11.Types.Message.Payload;

internal struct LocationPayload : IPayload<LocationPayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("lat"), JsonConverter(typeof(CqDoubleConverter))]
    public double Latitude { get; set; }

    [JsonInclude, JsonRequired, JsonPropertyName("lon"), JsonConverter(typeof(CqDoubleConverter))]
    public double Longitude { get; set; }

    [JsonInclude, JsonPropertyName("title")]
    public string? Title;

    [JsonInclude, JsonPropertyName("content")]
    public string? Content;

    public static LocationPayload Create(CqCode code) =>
        new()
        {
            Latitude = double.Parse(code.Payload["lat"], Defaults.DefaultFormat),
            Longitude = double.Parse(code.Payload["lon"], Defaults.DefaultFormat),
            Title = code.Payload.TryGetValue("title", out var title) ? title : null,
            Content = code.Payload.TryGetValue("content", out var content) ? content : null,
        };
}
