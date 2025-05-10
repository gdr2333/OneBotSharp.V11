using OneBotSharp.V11.Messages.Base;

namespace OneBotSharp.V11.Messages.Payload;

internal struct LocationPayload : IPayload<LocationPayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("lat"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public double Latitude { get; set; }

    [JsonInclude, JsonRequired, JsonPropertyName("lon"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
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
