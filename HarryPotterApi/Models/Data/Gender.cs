using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HarryPotterApi.Models.Data
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Character> Characters { get; set; }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Gender)
            {
                return false;
            }
            var other = obj as Gender;
            return Name.GetHashCode() == other!.Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"Gender({Id},{Name})";
        }
    }
}
