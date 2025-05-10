namespace OneBotSharp.V11.Datas.Event;

/// <summary>
/// 匿名信息类
/// </summary>
public class AnonymousData
{
    /// <summary>
    /// 匿名id
    /// </summary>
    [JsonInclude, JsonPropertyName("id"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public required long AnonymousId { get; init; }

    /// <summary>
    /// 匿名后的名称
    /// </summary>
    [JsonInclude, JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// 匿名flag，禁言用
    /// </summary>
    [JsonInclude, JsonPropertyName("flag")]
    public required string Flag { get; init; }
}
