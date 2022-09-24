using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api.Models.Data
{
    public class Hair
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Character> Characters { get; set; }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Hair)
            {
                return false;
            }
            var other = obj as Hair;
            return Name.GetHashCode() == other!.Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"Hair({Id},{Name})";
        }
    }
}
