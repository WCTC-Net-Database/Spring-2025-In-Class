using System.Text.Json;
using System.Text.Json.Serialization;
using W6_SOLID_DIP.Models;

namespace W6_SOLID_DIP.Data;

public class CharacterBaseConverter : JsonConverter<EntityBase>
{
    public override EntityBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            var root = doc.RootElement;
            var typeProperty = root.GetProperty("$type").GetString();
            Type type = typeProperty switch
            {
                "Character" => typeof(Character),
                "Goblin" => typeof(Goblin),
                "Ghost" => typeof(Ghost),
                _ => throw new NotSupportedException($"Type {typeProperty} is not supported")
            };
            return (EntityBase)JsonSerializer.Deserialize(root.GetRawText(), type, options);
        }
    }

    public override void Write(Utf8JsonWriter writer, EntityBase value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}