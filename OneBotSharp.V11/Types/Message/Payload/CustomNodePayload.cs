using OneBotSharp.V11.Types.Message.Base;
using OneBotSharp.V11.Utils.Converter;

namespace OneBotSharp.V11.Types.Message.Payload;

internal struct CustomNodePayload : IPayload<CustomNodePayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("user_id"), JsonConverter(typeof(CqLongConverter))]
    public long Uid;

    [JsonInclude, JsonRequired, JsonPropertyName("nickname")]
    public string Nickname;

    [JsonInclude, JsonRequired, JsonPropertyName("content")]
    public JsonValue Content;

    public static CustomNodePayload Create(CqCode code) =>
        new()
        {
            Uid = long.Parse(code.Payload["user_id"], Defaults.DefaultFormat),
            Nickname = code.Payload["nickname"],
            Content = (JsonValue)code.Payload["content"]
        };
}
