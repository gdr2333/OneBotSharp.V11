namespace OneBotSharp.V11.Datas.Event;

/// <summary>
/// 群消息发送者信息
/// </summary>
public class GroupMessageSender : MessageSender
{
    /// <summary>
    /// 群卡片信息
    /// </summary>
    [JsonInclude, JsonPropertyName("card")]
    public required string CardInfo { get; init; }

    /// <summary>
    /// 地区
    /// </summary>
    [JsonInclude, JsonPropertyName("area")]
    public required string Area { get; init; }

    /// <summary>
    /// 群等级
    /// </summary>
    [JsonInclude, JsonPropertyName("level")]
    public required string Level { get; init; }

    /// <summary>
    /// 管理员/群主/用户标识符
    /// </summary>
    [JsonInclude, JsonPropertyName("role")]
    public required string Role { get; init; }

    /// <summary>
    /// 群头衔
    /// </summary>
    [JsonInclude, JsonPropertyName("title")]
    public required string Title { get; init; }
}
