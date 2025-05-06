using OneBotSharp.V11.Message.Base;
using OneBotSharp.V11.Utils.Converter;

namespace OneBotSharp.V11.Message.Payload;

internal struct IdOnlyPayload : IPayload<IdOnlyPayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("id"), JsonConverter(typeof(CqLongConverter))]
    public long Id;

    public static IdOnlyPayload Create(CqCode code) =>
        new()
        {
            Id = long.Parse(code.Payload["id"], Defaults.DefaultFormat)
        };
}
