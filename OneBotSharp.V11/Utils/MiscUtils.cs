namespace OneBotSharp.V11.Utils;

internal static class MiscUtils
{
    public static ulong ToUnixTime(this DateTime dateTime) =>
        (ulong)Math.Round((dateTime - DateTime.UnixEpoch).TotalSeconds);

    public static DateTime FromUnixTime(ulong unixTime) =>
        DateTime.UnixEpoch.AddSeconds(unixTime);
}
