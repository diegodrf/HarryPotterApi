using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Repository.Models.Json
{
    internal class CharacterFromJson
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("alternate_names")]
        public List<string?> AlternateNames { get; set; }

        [JsonPropertyName("species")]
        public string? Species { get; set; }
        
        [JsonPropertyName("gender")]
        public string? Gender { get; set; }
        
        [JsonPropertyName("house")]
        public string? House { get; set; }

        [JsonPropertyName("dateOfBirth")]
        [JsonConverter(typeof(DateTimeCustomJsonConverter))]
        public DateTime? BirthDate { get; set; }

        [JsonPropertyName("wizard")]
        public bool? IsWizard { get; set; }

        [JsonPropertyName("ancestry")]
        public string? Ancestry { get; set; }

        [JsonPropertyName("eyeColour")]
        public string EyeColor { get; set; }

        [JsonPropertyName("hairColour")]
        public string? HairColor { get; set; }

        [JsonPropertyName("wand")]
        public WandFromJson? Wand { get; set; }

        [JsonPropertyName("patronus")]
        public string? Patronus { get; set; }

        [JsonPropertyName("hogwartsStudent")]
        public bool? IsHogwartsStudent { get; set; }

        [JsonPropertyName("hogwartsStaff")]
        public bool? IsHogwartsStaff { get; set; }

        [JsonPropertyName("actor")]
        public string? Actor { get; set; }

        [JsonPropertyName("alternate_actors")]
        public List<string?> AlternateActors { get; set; }

        [JsonPropertyName("alive")]
        public bool? IsAlive { get; set; }

        [JsonPropertyName("image")]
        public string? ImageUrl { get; set; }

        public override string ToString()
        {
            return $"CharacterJson({Name})";
        }
    }

    internal class DateTimeCustomJsonConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString()!, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        }
    }
}
