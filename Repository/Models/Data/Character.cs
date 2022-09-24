using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models.Data
{
    internal class Character
    {
        private static int _count = 1;
        private static int IncrementCount() => _count++;
        [Required]
        public string Name { get; set; } = string.Empty;
        public Hair? Hair { get; set; }
    }
}
