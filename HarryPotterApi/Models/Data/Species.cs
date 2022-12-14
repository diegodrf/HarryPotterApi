using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HarryPotterApi.Models.Data
{
    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        [JsonIgnore]
        public List<Character> Characters { get; set; } = default!;

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Species)
            {
                return false;
            }
            var other = obj as Species;
            return Name.GetHashCode() == other!.Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"Specie({Id},{Name})";
        }
    }
}
