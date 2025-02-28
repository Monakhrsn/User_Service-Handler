using Business.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Business.Helpers;

public class BaseUserConverter : JsonConverter<BaseUser>
{
    public override BaseUser? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonObject = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        var type = jsonObject.GetProperty("Type").GetString();

        return type switch
        {
            nameof(RegularUser) => JsonSerializer.Deserialize<RegularUser>(jsonObject.GetRawText(), options)!,
            nameof(AdminUser) => JsonSerializer.Deserialize<AdminUser>(jsonObject.GetRawText(), options)!,
            _ => throw new NotSupportedException($"User type {type} is not supported.")
        };
    }

    public override void Write(Utf8JsonWriter writer, BaseUser value, JsonSerializerOptions options)
    {
        var type = value.GetType().Name;
        var serializedObject = JsonSerializer.Serialize(value, value.GetType(), options);
        var jsonDocument = JsonDocument.Parse(serializedObject);

        writer.WriteStartObject();
        foreach (var property in jsonDocument.RootElement.EnumerateObject())
        {
            property.WriteTo(writer);
        }
        writer.WriteString("Type", type);
        writer.WriteEndObject();
    }
}