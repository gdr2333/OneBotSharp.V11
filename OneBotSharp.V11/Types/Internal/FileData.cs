namespace OneBotSharp.V11.Types.Internal;

internal class FileData
{
    public Uri? Url;

    public string? LocalPath;

    public HttpClient? HttpClient;

    public async Task<byte[]> GetData()
    {
        if (LocalPath is not null && File.Exists(LocalPath))
            return await File.ReadAllBytesAsync(LocalPath);
        else if (Url is not null && HttpClient is not null)
            return await HttpClient.GetByteArrayAsync(Url);
        else throw new FileNotFoundException("本地文件不存在或不可用，并且没有设置远程地址。");
    }
}
