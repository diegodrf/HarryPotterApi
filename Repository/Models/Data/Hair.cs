using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models.Data
{
    internal class Hair
    {
        private static int _count = 1;
        private static int IncrementCount() => _count++;

        public int Id { get; set; } = IncrementCount();

        [Required]
        public string Name { get; set; } = string.Empty;

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
