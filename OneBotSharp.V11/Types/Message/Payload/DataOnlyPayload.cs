using OneBotSharp.V11.Types.Message.Base;

namespace OneBotSharp.V11.Types.Message.Payload;

internal struct DataOnlyPayload : IPayload<DataOnlyPayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("data")]
    public string Data;

    public static DataOnlyPayload Create(CqCode code) =>
        new()
        {
            Data = code.Payload["data"]
        };
}
