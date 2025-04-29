using OneBotSharp.V11.Types.Message.Base;
using OneBotSharp.V11.Types.Message.Payload;

namespace OneBotSharp.V11.Types.Message;

/// <summary>
/// 视频消息段
/// </summary>
public class VideoSegment : Segment
{
    /// <inheritdoc/>
    public override string Type => "video";

    /// <inheritdoc/>
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 接收的时候是文件名，发送的时候是文件地址或者文件名
    /// </summary>
    [JsonIgnore]
    public string FileName { get; private init; }

    /// <summary>
    /// 视频URL（仅限接收）
    /// </summary>
    [JsonIgnore]
    public Uri? Url { get; private init; }

    /// <summary>
    /// 是否使用缓存（仅限发送）
    /// </summary>
    [JsonIgnore]
    public bool UseCache { get; private init; }

    /// <summary>
    /// 是否使用系统代理（仅限发送）
    /// </summary>
    [JsonIgnore]
    public bool UseProxy { get; private init; }

    /// <summary>
    /// 超时时间（仅限发送）
    /// </summary>
    [JsonIgnore]
    public int? Timeout { get; private init; }

    [JsonIgnore]
    private readonly JsonNode _payload;

    /// <summary>
    /// 用指定字符串创建一个视频消息段
    /// </summary>
    /// <param name="fileName">文件名或URL</param>
    /// <param name="useCache">是否使用缓存</param>
    /// <param name="useProxy">是否使用系统代理</param>
    /// <param name="timeout">超时时间</param>
    public VideoSegment(string fileName, bool useCache = Defaults.CqUseCacheDefault, bool useProxy = Defaults.CqUseProxyDefault, int? timeout = null)
    {
        FileName = fileName;
        Url = null;
        UseCache = useCache;
        UseProxy = useProxy;
        Timeout = timeout;
        JsonObject payload = new()
        {
            {"file", FileName}
        };
        if (useCache != Defaults.CqUseCacheDefault)
            payload.Add("cache", CqCodeUtil.CqBoolEncoode(useCache));
        if (useProxy != Defaults.CqUseProxyDefault)
            payload.Add("proxy", CqCodeUtil.CqBoolEncoode(useProxy));
        if (timeout is not null)
            payload.Add("timeout", timeout);
        _payload = payload;
    }

    /// <summary>
    /// 用指定URL创建一个视频消息段
    /// </summary>
    /// <param name="fileUrl">文件URL</param>
    /// <param name="useCache">是否使用缓存</param>
    /// <param name="useProxy">是否使用系统代理</param>
    /// <param name="timeout">超时时间</param>
    public VideoSegment(Uri fileUrl, bool useCache = Defaults.CqUseCacheDefault, bool useProxy = Defaults.CqUseProxyDefault, int? timeout = null)
        : this(fileUrl.AbsoluteUri, useCache, useProxy, timeout)
    {
    }

    /// <summary>
    /// 用指定二进制内容创建一个视频消息段
    /// </summary>
    /// <param name="file">二进制内容</param>
    public VideoSegment(byte[] file)
        : this($"base64://{Convert.ToBase64String(file)}")
    {
    }


    internal VideoSegment(VideoPayload payload, JsonNode payloadNode)
    {
        FileName = payload.File;
        Url = payload.Url;
        UseCache = payload.UseCache;
        UseProxy = payload.UseProxy;
        Timeout = payload.TimeOut;
        _payload = payloadNode;
    }
}
