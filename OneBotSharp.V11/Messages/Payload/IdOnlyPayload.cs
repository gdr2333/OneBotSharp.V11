using OneBotSharp.V11.Messages.Base;

namespace OneBotSharp.V11.Messages.Payload;

internal struct IdOnlyPayload : IPayload<IdOnlyPayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("id"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long Id;

    public static IdOnlyPayload Create(CqCode code) =>
        new()
        {
            Id = long.Parse(code.Payload["id"], Defaults.DefaultFormat)
        };
}
