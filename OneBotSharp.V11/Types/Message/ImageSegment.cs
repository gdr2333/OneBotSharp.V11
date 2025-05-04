using OneBotSharp.V11.Types.Message.Base;
using OneBotSharp.V11.Types.Message.Payload;

namespace OneBotSharp.V11.Types.Message;

/// <summary>
/// 图片消息段
/// </summary>
public class ImageSegment : Segment
{
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override string Type => "image";

    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 接收的时候是文件名，发送的时候是文件地址或者文件名
    /// </summary>
    [JsonIgnore]
    public string FileName { get; private init; }

    /// <summary>
    /// 是否为闪照
    /// </summary>
    [JsonIgnore]
    public bool IsFlash { get; private init; }

    /// <summary>
    /// 图片URL（仅限接收）
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

    private readonly JsonNode _payload;

    /// <summary>
    /// 创建新的图片消息段
    /// </summary>
    /// <param name="fileName">图片名或URL</param>
    /// <param name="isFlash">是否为闪照</param>
    /// <param name="useCache">是否使用缓存</param>
    /// <param name="useProxy">是否使用系统代理</param>
    /// <param name="timeout">超时时间</param>
    public ImageSegment(string fileName, bool isFlash = false, bool useCache = Defaults.CqUseCacheDefault, bool useProxy = Defaults.CqUseProxyDefault, int? timeout = null)
    {
        FileName = fileName;
        IsFlash = isFlash;
        Url = null;
        UseCache = useCache;
        UseProxy = useProxy;
        Timeout = timeout;
        var payload = new JsonObject()
        {
            {"file", fileName },
        };
        if (isFlash)
            payload.Add("type", "flash");
        if (useCache != Defaults.CqUseCacheDefault)
            payload.Add("cache", CqCodeUtil.CqBoolEncoode(useCache));
        if (useProxy != Defaults.CqUseProxyDefault)
            payload.Add("proxy", CqCodeUtil.CqBoolEncoode(useProxy));
        if (timeout is not null)
            payload.Add("timeout", timeout);
        _payload = payload;
    }

    /// <summary>
    /// 创建新的图片消息段
    /// </summary>
    /// <param name="fileUrl">图片URL</param>
    /// <param name="isFlash">是否为闪照</param>
    /// <param name="useCache">是否使用缓存</param>
    /// <param name="useProxy">是否使用系统代理</param>
    /// <param name="timeout">超时时间</param>
    public ImageSegment(Uri fileUrl, bool isFlash = false, bool useCache = Defaults.CqUseCacheDefault, bool useProxy = Defaults.CqUseProxyDefault, int? timeout = null)
        : this(fileUrl.AbsoluteUri, isFlash, useCache, useProxy, timeout)
    {
    }

    /// <summary>
    /// 创建新的图片消息段
    /// </summary>
    /// <param name="file">图片内容</param>
    /// <param name="isFlash">是否为闪照</param>
    public ImageSegment(byte[] file, bool isFlash = false)
        : this($"base64://{Convert.ToBase64String(file)}", isFlash)
    {
    }

    internal ImageSegment(ImagePayload payload, JsonNode payloadNode)
    {
        FileName = payload.File;
        IsFlash = payload.ImageType == "flash";
#pragma warning disable CS0618
        Url = payload.Url;
#pragma warning restore CS0618
        UseCache = Defaults.CqUseCacheDefault;
        UseProxy = Defaults.CqUseProxyDefault;
        Timeout = null;
        _payload = payloadNode;
    }
}
