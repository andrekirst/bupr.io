#nullable enable
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class Hierarchy
    {
        [JsonPropertyName("items")]
        public List<HierarchyItem> Items { get; set; } = new List<HierarchyItem>();
    }

    public class HierarchyItem
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(HierarchyItemIdJsonConverter))]
        public HierarchyItemId? Id { get; set; }

        [JsonPropertyName("name")]
        public Name? Name { get; set; }

        [JsonPropertyName("items")]
        public List<HierarchyItem> Items { get; set; } = new List<HierarchyItem>();

        [JsonPropertyName("level")]
        public ulong Level { get; set; }

        [JsonPropertyName("sections")]
        public List<Section> Sections { get; set; } = new List<Section>();

        public override string ToString() => $"{Id} - {Name}";
    }

    public class Section
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(SectionIdJsonConverter))]
        public SectionId? Id { get; set; }

        [JsonPropertyName("name")]
        public Name? Name { get; set; }

        [JsonPropertyName("order")]
        public ulong Order { get; set; }

        [JsonPropertyName("properties")]
        public List<Property> Properties { get; set; } = new List<Property>();

        public override string ToString() => $"{Id}: {Name} : {Order}";
    }

    public class Property
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(PropertyIdJsonConverter))]
        public PropertyId? Id { get; set; }

        [JsonPropertyName("technicalName")]
        [JsonConverter(typeof(TechnicalNameJsonConverter))]
        public TechnicalName? TechnicalName { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(PropertyTypeJsonConverter))]
        public PropertyType? Type { get; set; }

        [JsonPropertyName("values")]
        public List<PropertyValue> Values { get; set; } = new List<PropertyValue>();
    }

    public class PropertyValue
    {
        [JsonPropertyName("targetName")]
        [JsonConverter(typeof(TargetNameJsonConverter))]
        public TargetName? TargetName { get; set; }

        [JsonPropertyName("nameValue")]
        public Name? NameValue { get; set; }

        [JsonPropertyName("variableName")]
        [JsonConverter(typeof(VariableNameJsonConverter))]
        public VariableName? VariableName { get; set; }
    }

    public class VariableName
    {
        public string Name { get; }

        public VariableName(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Name = name;
        }
    }

    public class VariableNameJsonConverter : JsonConverter<VariableName?>
    {
        public override VariableName? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(VariableName) ? new VariableName(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, VariableName? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Name);
        }
    }

    public class TargetName
    {
        public string Name { get; }

        public TargetName(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Name = name;
        }
    }

    public class TargetNameJsonConverter : JsonConverter<TargetName?>
    {
        public override TargetName? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(TargetName) ? new TargetName(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, TargetName? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Name);
        }
    }

    public class PropertyType
    {
        public static IList<string> ValidValues = new List<string> { "label", "text", "date", "time", "checkbox" };

        public string Type { get; }

        public PropertyType(string type)
        {
            Guard.Against.NullOrWhiteSpace(type, nameof(type));
            Guard.Against.NotMatchRegex(type, nameof(type), @"^[a-z][a-z\d\-]{1,}$");
            Guard.Against.SplittedValues(type, nameof(type), '-', ValidValues);
            Type = type;
        }

        public override string ToString() => Type;
    }

    public class PropertyTypeJsonConverter : JsonConverter<PropertyType?>
    {
        public override PropertyType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(PropertyType) ? new PropertyType(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, PropertyType? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Type);
        }
    }

    public class TechnicalName
    {
        public string Name { get; }

        public TechnicalName(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.NotMatchRegex(name, nameof(name), @"^[a-zA-Z\-]{1,}$");
            Name = name;
        }

        public override string ToString() => Name;
    }

    public class TechnicalNameJsonConverter : JsonConverter<TechnicalName?>
    {
        public override TechnicalName? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(TechnicalName) ? new TechnicalName(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, TechnicalName? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Name);
        }
    }

    public class PropertyId
    {
        public string Id { get; }

        public PropertyId(string id)
        {
            Guard.Against.NullOrWhiteSpace(id, nameof(id));
            Id = id;
        }
    }

    public class PropertyIdJsonConverter : JsonConverter<PropertyId?>
    {
        public override PropertyId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(PropertyId) ? new PropertyId(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, PropertyId? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Id ?? string.Empty);
        }
    }

    public class SectionId
    {
        public string Id { get; }

        public SectionId(string id)
        {
            Guard.Against.NullOrWhiteSpace(id, nameof(id));
            Id = id;
        }

        public override string ToString() => Id;
    }

    public class SectionIdJsonConverter : JsonConverter<SectionId?>
    {
        public override SectionId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(SectionId) ? new SectionId(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, SectionId? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Id ?? string.Empty);
        }
    }

    public class HierarchyItemId
    {
        public string Id { get; }

        public HierarchyItemId(string id)
        {
            Guard.Against.NullOrWhiteSpace(id, nameof(id));
            Id = id;
        }

        public override string ToString() => Id;
    }

    public class HierarchyItemIdJsonConverter : JsonConverter<HierarchyItemId?>
    {
        public override HierarchyItemId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(HierarchyItemId) ? new HierarchyItemId(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, HierarchyItemId? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Id ?? string.Empty);
        }
    }
}