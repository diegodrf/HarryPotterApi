using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models.Data
{
    internal class Gender
    {
        private static int _count = 1;
        private static int IncrementCount() => _count++;

        public int Id { get; set; } = IncrementCount();
        public string Name { get; set; }

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
