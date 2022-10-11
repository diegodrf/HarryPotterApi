using System.Text.Json.Serialization;

namespace HarryPotterApi.Domain.Entities
{
    public class Gender : Entity
    {
        public string Name { get; set; } = default!;
        [JsonIgnore]
        public ICollection<Character> Characters { get; set; } = default!;
    }
}
