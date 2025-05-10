namespace OneBotSharp.V11.Utils.Converter;

internal class UnixTimeToDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return MiscUtils.FromUnixTime(reader.GetUInt64());
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.ToUnixTime());
    }
}
