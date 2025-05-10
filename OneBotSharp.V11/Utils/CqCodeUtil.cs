using OneBotSharp.V11.Messages.Base;

namespace OneBotSharp.V11.Utils;

internal static class CqCodeUtil
{
    public static bool CqBoolDecode(string val) =>
        val.ToLower(Defaults.DefaultFormat) switch
        {
            "1" or "true" or "yes" => true,
            "0" or "false" or "no" => false,
            _ => throw new FormatException($"{val}在这里是无效的。")
        };

    public static string CqBoolEncoode(bool val) =>
        val ? "1" : "0";

    private static string CqCodePropValueEncode(string value) => 
        value.Replace("&", "&amp;").Replace("[", "&#91;").Replace("]", "&#93;").Replace(",", "&#44;");

    private static string CqCodePropValueDecode(string value) => 
        value.Replace("&amp;", "&").Replace("&#91;", "[").Replace("&#93;", "]").Replace("&#44;", ",");

    internal static string CqCodeTextEncode(string value) => 
        value.Replace("&", "&amp;").Replace("[", "&#91;").Replace("]", "&#93;");

    internal static string CqCodeTextDecode(string value) => 
        value.Replace("&amp;", "&").Replace("&#91;", "[").Replace("&#93;", "]");

    public static CqCode CqCodeDecode(string val)
    {
        string type;
        Dictionary<string, string> payload = [];
        if (val.StartsWith('[') && val.EndsWith(']'))
        {
            var values = val[1..^1].Split(',');
            type = values[0][3..];
            foreach (var i in values[1..])
            {
                var s = i.IndexOf('=');
                if (s == -1)
                    payload.Add(i, "");
                else
                    payload.Add(i[..s], CqCodePropValueDecode(i[(s + 1)..]));
            }
        }
        else
        {
            type = "text";
            payload.Add("text", CqCodeTextDecode(val));
        }
        return new(type, payload);
    }

    public static string CqCodeEncode(CqCode val)
    {
        if (val.Type == "text")
            return CqCodeTextEncode(val.Payload["text"]);
        StringBuilder sb = new("[CQ:");
        sb.Append(val.Type);
        sb.Append(',');
        foreach (var i in val.Payload)
        {
            sb.Append(i.Key);
            if (!string.IsNullOrEmpty(i.Value))
            {
                sb.Append('=');
                sb.Append(CqCodePropValueEncode(i.Value));
            }
            sb.Append(',');
        }
        sb[^1] = ']';
        return sb.ToString();
    }

    public static CqCode JsonPayloadToCqCode(string type, JsonNode payload)
    {
        Dictionary<string, string> data = [];
        foreach(var i in payload.AsObject())
            switch (i.Value?.GetValueKind())
            {
                case null:
                case JsonValueKind.Array:
                case JsonValueKind.Object:
                    continue;
                case JsonValueKind.False:
                    data.Add(i.Key, "false");
                    continue;
                case JsonValueKind.Null:
                case JsonValueKind.Undefined:
                    data.Add(i.Key, "");
                    continue;
                case JsonValueKind.Number:
                    // JSON SUCKS
                    data.Add(i.Key, i.Value.GetValue<double>().ToString(Defaults.DefaultFormat));
                    continue;
                case JsonValueKind.String:
                    data.Add(i.Key, i.Value.GetValue<string>());
                    continue;
                case JsonValueKind.True:
                    data.Add(i.Key, "true");
                    continue;
            }
        return new(type, data);
    }
}
