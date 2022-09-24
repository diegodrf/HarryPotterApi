using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api.Models.Json
{
    public class WandFromJson
    {
        [JsonPropertyName("wood")]
        public string? Wood { get; set; }
        [JsonPropertyName("core")]
        public string? Core { get; set; }
        [JsonPropertyName("length")]
        public double? Length { get; set; }
    }
}
