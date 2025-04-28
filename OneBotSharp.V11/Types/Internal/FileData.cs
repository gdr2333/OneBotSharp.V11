namespace OneBotSharp.V11.Types.Internal;

internal class FileData
{
    public Uri? Url;

    public string? LocalPath;

    public HttpClient? HttpClient;

    private WeakReference<byte[]>? Cache;

    public async Task<byte[]> GetData()
    {
        if (Cache is not null && Cache.TryGetTarget(out var value))
            return value;
        else if (LocalPath is not null && File.Exists(LocalPath))
        {
            var val = await File.ReadAllBytesAsync(LocalPath);
            Cache = new(val);
            return val;
        }
        else if (Url is not null && HttpClient is not null)
        {
            var val = await HttpClient.GetByteArrayAsync(Url);
            Cache = new(val);
            return val;
        }
        else throw new FileNotFoundException("本地文件不存在或不可用，并且没有设置远程地址。");
    }
}
