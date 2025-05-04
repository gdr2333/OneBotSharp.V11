using OneBotSharp.V11.Types.Message.Base;
using OneBotSharp.V11.Types.Message.Payload;

namespace OneBotSharp.V11.Types.Message;

/// <summary>
/// 位置分享消息段
/// </summary>
public class LocationSegment : Segment
{
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("type")]
    public override string Type => "Location";

    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 纬度
    /// </summary>
    [JsonIgnore]
    public double Latitude { get; set; }

    /// <summary>
    /// 经度
    /// </summary>
    [JsonIgnore]
    public double Longitude { get; set; }

    /// <summary>
    /// （可选）标题
    /// </summary>
    [JsonIgnore]
    public string? Title { get; private init; }

    /// <summary>
    /// （可选）描述
    /// </summary>
    [JsonIgnore]
    public string? Content { get; private init; }

    [JsonIgnore]
    private readonly JsonNode _payload;

    /// <summary>
    /// 新建一个位置分享消息段
    /// </summary>
    /// <param name="latitude">纬度</param>
    /// <param name="longitude">经度</param>
    /// <param name="title">标题</param>
    /// <param name="content">描述</param>
    public LocationSegment(double latitude, double longitude, string? title = null, string? content = null)
    {
        Latitude = latitude;
        Longitude = longitude;
        Title = title;
        Content = content;
        var payload = new JsonObject()
        {
            { "lat", Latitude},
            { "lon", Longitude }
        };
        if(title is not null)
            payload.Add("title", title);
        if(content is not null)
            payload.Add("content", content);
        _payload = payload;
    }

    internal LocationSegment(LocationPayload payload, JsonNode? payloadNode)
    {
        Latitude = payload.Latitude;
        Longitude = payload.Longitude;
        Title = payload.Title;
        Content = payload.Content;
        _payload = payloadNode ?? JsonValue.Create(payload) ?? throw new JsonException("JsonValue.Create出现内部错误");
    }
}
