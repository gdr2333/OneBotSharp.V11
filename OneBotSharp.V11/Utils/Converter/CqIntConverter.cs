namespace OneBotSharp.V11.Utils.Converter;

internal class CqIntConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType switch
        {
            JsonTokenType.String => int.Parse(reader.GetString(), MiscUtil.DefaultFormat),
            JsonTokenType.Number => reader.GetInt32(),
            JsonTokenType.True => 1,
            JsonTokenType.False => 0,
            _ => throw new JsonException($"{reader.TokenType}怎么想也不是Int32吧？"),
        };

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString(MiscUtil.DefaultFormat));
}
