namespace OneBotSharp.V11.Messages.Payload;

internal struct SegmentPayload
{
    [JsonInclude, JsonRequired, JsonPropertyName("type")]
    public string Type;

    [JsonInclude, JsonRequired, JsonPropertyName("data")]
    public JsonNode Payload;
}
