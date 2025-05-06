namespace OneBotSharp.V11.Message.Payload;

internal struct SegmentPayload
{
    [JsonInclude, JsonRequired, JsonPropertyName("type")]
    public string Type;

    [JsonInclude, JsonRequired, JsonPropertyName("data")]
    public JsonNode Payload;
}
