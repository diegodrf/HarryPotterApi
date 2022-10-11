using System.Text.Json.Serialization;

namespace HarryPotterApi.Domain.Entities
{
    public class Wand : Entity
    {
        public string? Wood { get; set; }
        public string? Core { get; set; }
        public double? Length { get; set; }
        [JsonIgnore]
        public ICollection<Character> Characters { get; set; } = default!;
    }
}
