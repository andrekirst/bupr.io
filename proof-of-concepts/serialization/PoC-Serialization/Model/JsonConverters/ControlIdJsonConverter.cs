﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PoC_Serialization.Model.Ids;
using PoC_Serialization.Model.ProcessdefinitionResearch;

namespace PoC_Serialization.Model.JsonConverters
{
    public class ControlIdJsonConverter : JsonConverter<ControlId>
    {
        public override ControlId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(ControlId) ? new ControlId(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, ControlId? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Id ?? string.Empty);
        }
    }
}