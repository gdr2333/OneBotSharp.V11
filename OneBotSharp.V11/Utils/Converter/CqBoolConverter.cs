namespace OneBotSharp.V11.Utils.Converter;

internal class CqBoolConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.TokenType switch
        {
            JsonTokenType.String => CqCodeUtil.CqBoolDecode(reader.GetString()),
            JsonTokenType.Number => reader.GetInt16() != 0,// 不会有**往里面写1.0或者2^50吧？
            JsonTokenType.True => true,
            JsonTokenType.False => false,
            _ => throw new JsonException($"把{reader.TokenType}当bool又是个什么鬼实现方式？"),
        };

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        => writer.WriteStringValue(value ? "1" : "0");
}
