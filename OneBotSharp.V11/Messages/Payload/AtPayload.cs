using OneBotSharp.V11.Messages.Base;

namespace OneBotSharp.V11.Messages.Payload;

internal struct AtPayload : IPayload<AtPayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("qq")]
    public string QQ;

    public static AtPayload Create(CqCode code) =>
        new()
        {
            QQ = code.Payload["qq"]
        };
}
