using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using PoC_Serialization.Model.ProcessdefinitionResearch.Validations;

namespace PoC_Serialization.Model.JsonConverters
{
    public class ValidationTypeConverter<T> : JsonConverter<T>
        where T : IValidationType
    {
        private readonly List<Type> _types;

        public ValidationTypeConverter()
        {
            var type = typeof(T);
            _types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract)
                .ToList();
        }
        
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            using (var jsonDocument = JsonDocument.ParseValue(ref reader))
            {
                if (!jsonDocument.RootElement.TryGetProperty(nameof(IValidationType.ValidationTypeName), out var typeProperty))
                {
                    throw new JsonException();
                }

                var type = _types.FirstOrDefault(x => x.Name == typeProperty.GetString());
                if (type == null)
                {
                    throw new JsonException();
                }

                var jsonObject = jsonDocument.RootElement.GetRawText();
                var result = (T)JsonSerializer.Deserialize(jsonObject, type);

                return result;
            }
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }
}