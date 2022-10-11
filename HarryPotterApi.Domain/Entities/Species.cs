using System.Text.Json.Serialization;

namespace HarryPotterApi.Domain.Entities
{
    public class Species : Entity
    {
        public string Name { get; set; } = default!;
        [JsonIgnore]
        public ICollection<Character> Characters { get; set; } = default!;
    }
}
