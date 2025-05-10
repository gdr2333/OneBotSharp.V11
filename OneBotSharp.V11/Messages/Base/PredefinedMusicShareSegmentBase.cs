using OneBotSharp.V11.Messages.Payload;

namespace OneBotSharp.V11.Messages.Base;

/// <summary>
/// 预定义（type不是costom）音乐分享的基类
/// </summary>
public abstract class PredefinedMusicShareSegmentBase : MusicShareSegmentBase
{
    /// <inheritdoc/>
    [JsonIgnore]
    public override string MusicShareType => _musicShareType;

    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 音乐ID
    /// </summary>
    [JsonIgnore]
    public long MusicId { get; internal init; }

    [JsonIgnore]
    private readonly string _musicShareType;

    [JsonIgnore]
    private readonly JsonNode _payload;

    /// <summary>
    /// 用指定类型和音乐ID创建一个音乐分享
    /// </summary>
    /// <param name="musicShareType">音乐分享类型</param>
    /// <param name="musicId">音乐ID</param>
    public PredefinedMusicShareSegmentBase(string musicShareType, long musicId)
    {
        _musicShareType = musicShareType;
        MusicId = musicId;
        _payload = new JsonObject()
        {
            { "type", musicShareType },
            { "id", musicId }
        };
    }

    internal PredefinedMusicShareSegmentBase(MusicSharePayload payload, JsonNode? payloadNode)
    {
        _musicShareType = payload.Type;
        MusicId = payload.Id;
        _payload = payloadNode ?? JsonValue.Create(payload) ?? throw new JsonException("JsonValue.Create出现内部错误");
    }
}
