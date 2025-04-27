using System.Text.Json.Serialization;

namespace OneBotSharp.V11.Utils.Converter;

internal class CqLongConverter : JsonConverter<long>
{
    public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.String => long.Parse(reader.GetString(), MiscUtil.DefaultFormat),
            JsonTokenType.Number => reader.GetInt64(),
            JsonTokenType.True => 1,
            JsonTokenType.False => 0,
            _ => throw new JsonException($"{reader.TokenType}怎么想也不是Int64吧？"),
        };
    }

    public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value);
    }
}
