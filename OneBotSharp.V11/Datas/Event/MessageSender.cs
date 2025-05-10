namespace OneBotSharp.V11.Datas.Event;

/// <summary>
/// 消息发送者信息
/// </summary>
public class MessageSender
{
    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonInclude, JsonPropertyName("user_id"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public required ulong Uid { get; init; }

    /// <summary>
    /// 用户昵称
    /// </summary>
    [JsonInclude, JsonPropertyName("nickname")]
    public required string Nickname { get; init; }

    /// <summary>
    /// 用户标记的性别
    /// </summary>
    [JsonInclude, JsonPropertyName("sex")]
    public required string Gender { get; init; }

    /// <summary>
    /// 用户年龄
    /// </summary>
    // 我不认为我的代码可以用21亿年
    [JsonInclude, JsonPropertyName("age"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public required int Age { get; init; }
}
