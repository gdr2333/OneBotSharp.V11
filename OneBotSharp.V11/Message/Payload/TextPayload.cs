using OneBotSharp.V11.Message.Base;

namespace OneBotSharp.V11.Message.Payload;

internal struct TextPayload : IPayload<TextPayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("text")]
    public string Text;

    public static TextPayload Create(CqCode code) =>
        new()
        {
            Text = code.Payload["text"]
        };
}
