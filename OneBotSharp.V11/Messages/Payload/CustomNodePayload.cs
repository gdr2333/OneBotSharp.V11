using OneBotSharp.V11.Messages.Base;

namespace OneBotSharp.V11.Messages.Payload;

internal struct CustomNodePayload : IPayload<CustomNodePayload>
{
    [JsonInclude, JsonRequired, JsonPropertyName("user_id"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
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
