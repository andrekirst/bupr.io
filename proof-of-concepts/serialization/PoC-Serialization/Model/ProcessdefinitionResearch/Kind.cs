﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class Kind
    {
        public string Value { get; }
        public static List<string> ValidKindValues = new List<string>{ "ProcessDefinition", "ProcessInstance" };

        public Kind()
        {
        }

        public Kind(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value can not be empty or whitespace", nameof(value));
            }

            if (ValidKindValues.All(kind => kind != value))
            {
                throw new ArgumentException("No valid kind value");
            }

            Value = value;
        }

        public override string ToString() => Value;

        public static implicit operator string(Kind kind) => kind.ToString();
        public static explicit operator Kind(string value) => new Kind(value);
    }

    public class KindJsonConverter : JsonConverter<Kind>
    {
        public override Kind Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(Kind) ? new Kind(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, Kind value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}