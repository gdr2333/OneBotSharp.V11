using OneBotSharp.V11.Messages.Base;
using OneBotSharp.V11.Messages.Payload;

namespace OneBotSharp.V11.Messages;

/// <summary>
/// 语音消息段
/// </summary>
public class RecordSegment : Segment
{
    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("type")]
    public override string Type => "record";

    /// <inheritdoc/>
    [JsonInclude, JsonPropertyName("data")]
    public override JsonNode Payload => _payload;

    /// <summary>
    /// 文件名或文件URL
    /// </summary>
    [JsonIgnore]
    public string FileName { get; private init; }

    /// <summary>
    /// 是否启用变声
    /// </summary>
    [JsonIgnore]
    public bool UseMagic { get; private init; }

    /// <summary>
    /// （仅接收）文件URL
    /// </summary>
    [JsonIgnore]
    public Uri? Url { get; private init; }

    /// <summary>
    /// （仅发送）是否使用缓存
    /// </summary>
    [JsonIgnore]
    public bool UseCache { get; private init; }

    /// <summary>
    /// （仅发送）是否使用系统代理
    /// </summary>
    [JsonIgnore]
    public bool UseProxy { get; private init; }

    /// <summary>
    /// （仅发送）超时时间
    /// </summary>
    [JsonIgnore]
    public int? Timeout { get; private init; }

    /// <summary>
    /// （扩展）文件本地地址
    /// </summary>
    [JsonIgnore]
    public string? FileAddress { get; private init; }

    [JsonIgnore]
    private readonly JsonNode _payload;

    /// <summary>
    /// 用指定字符串创建一个录音消息段
    /// </summary>
    /// <param name="fileName">文件名或URL</param>
    /// <param name="useMagic">是否变声</param>
    /// <param name="useCache">是否使用缓存</param>
    /// <param name="useProxy">是否使用系统代理</param>
    /// <param name="timeout">超时时间</param>
    /// <param name="fileAddress">额外的本地文件地址</param>
    public RecordSegment(string fileName, bool useMagic = false, bool useCache = Defaults.CqUseCacheDefault, bool useProxy = Defaults.CqUseProxyDefault, int? timeout = null, string? fileAddress = null)
    {
        FileName = fileName;
        UseMagic = useMagic;
        Url = null;
        UseCache = useCache;
        UseProxy = useProxy;
        Timeout = timeout;
        FileAddress = File.Exists(fileAddress) ? fileAddress : null;
        JsonObject payload = new()
        {
            {"file", FileName}
        };
        if (useMagic)
            payload.Add("magic", CqCodeUtil.CqBoolEncoode(true));
        if (useCache != Defaults.CqUseCacheDefault)
            payload.Add("cache", CqCodeUtil.CqBoolEncoode(useCache));
        if (useProxy != Defaults.CqUseProxyDefault)
            payload.Add("proxy", CqCodeUtil.CqBoolEncoode(useProxy));
        if (timeout is not null)
            payload.Add("timeout", timeout);
        _payload = payload;
    }

    /// <summary>
    /// 用指定URL创建一个录音消息段
    /// </summary>
    /// <param name="fileUrl">文件URL</param>
    /// <param name="useMagic">是否变声</param>
    /// <param name="useCache">是否使用缓存</param>
    /// <param name="useProxy">是否使用系统代理</param>
    /// <param name="timeout">超时时间</param>
    /// <param name="fileAddress">额外的本地文件地址</param>
    public RecordSegment(Uri fileUrl, bool useMagic = false, bool useCache = Defaults.CqUseCacheDefault, bool useProxy = Defaults.CqUseProxyDefault, int? timeout = null, string? fileAddress = null)
        : this(fileUrl.AbsoluteUri, useMagic, useCache, useProxy, timeout, fileAddress)
    {
    }

    /// <summary>
    /// 用指定二进制内容创建一个录音消息段
    /// </summary>
    /// <param name="file">二进制内容</param>
    /// <param name="useMagic">是否变声</param>
    public RecordSegment(byte[] file, bool useMagic = false)
        : this($"base64://{Convert.ToBase64String(file)}", useMagic)
    {
    }


    internal RecordSegment(RecordPayload payload, JsonNode? payloadNode, string? fileAddress = null)
    {
        FileName = payload.File;
        UseMagic = payload.UseMagic;
        Url = payload.Url;
        UseCache = payload.UseCache;
        UseProxy = payload.UseProxy;
        Timeout = payload.TimeOut;
        FileAddress = File.Exists(fileAddress) ? fileAddress : null;
        _payload = payloadNode ?? JsonValue.Create(payload) ?? throw new JsonException("JsonValue.Create出现内部错误");
    }
}
