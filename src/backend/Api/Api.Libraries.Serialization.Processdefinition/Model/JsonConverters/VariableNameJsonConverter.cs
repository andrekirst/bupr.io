﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.Libraries.Serialization.Processdefinition.Model.JsonConverters
{
    public class VariableNameJsonConverter : JsonConverter<VariableName?>
    {
        public override VariableName? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(VariableName) ? new VariableName(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, VariableName? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Name);
        }
    }
}
