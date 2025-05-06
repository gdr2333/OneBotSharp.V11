using OneBotSharp.V11.Message.Base;
using OneBotSharp.V11.Utils.Converter;

namespace OneBotSharp.V11.Message.Payload;

internal struct ContactPayload : IPayload<ContactPayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("type")]
    public string Type;

    [JsonInclude, JsonRequired, JsonPropertyName("id"), JsonConverter(typeof(CqLongConverter))]
    public long Id;

    public static ContactPayload Create(CqCode code) =>
        new()
        {
            Type = code.Payload["type"],
            Id = long.Parse(code.Payload["id"], Defaults.DefaultFormat)
        };
}
