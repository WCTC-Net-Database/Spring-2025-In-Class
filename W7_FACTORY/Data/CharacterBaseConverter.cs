﻿using System.Text.Json;
using System.Text.Json.Serialization;
using W7_FACTORY.Models.Characters;

namespace W7_FACTORY.Data;

public class CharacterBaseConverter : JsonConverter<CharacterBase>
{
    public override CharacterBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
            return (CharacterBase)JsonSerializer.Deserialize(root.GetRawText(), type, options);
        }
    }

    public override void Write(Utf8JsonWriter writer, CharacterBase value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}