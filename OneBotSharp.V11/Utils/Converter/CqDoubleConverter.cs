namespace OneBotSharp.V11.Utils.Converter;

internal class CqDoubleConverter : JsonConverter<double>
{
    public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType switch
        {
            JsonTokenType.String => double.Parse(reader.GetString(), MiscUtil.DefaultFormat),
            JsonTokenType.Number => reader.GetDouble(),
            _ => throw new JsonException($"{reader.TokenType}怎么想也不是FP64吧？"),
        };

    public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString(MiscUtil.DefaultFormat));
}
