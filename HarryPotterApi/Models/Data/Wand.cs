using System.Text.Json.Serialization;

namespace HarryPotterApi.Models.Data
{
    public class Wand
    {
        public int Id { get; set; }
        public string? Wood { get; set; }
        public string? Core { get; set; }
        public double? Length { get; set; }
        [JsonIgnore]
        public List<Character> Characters { get; set; } = default!;
    }
}
