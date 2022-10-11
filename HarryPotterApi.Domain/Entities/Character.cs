using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HarryPotterApi.Domain.Entities
{
    public class Character : Entity
    {
        public string Name { get; set; } = default!;

        public Species? Species { get; set; }
        [JsonIgnore]
        public int? SpeciesId { get; set; }

        public Gender? Gender { get; set; }
        [JsonIgnore]
        public int? GenderId { get; set; }

        public House? House { get; set; }
        [JsonIgnore]
        public int? HouseId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        public bool IsWizard { get; set; }

        public string? Ancestry { get; set; }

        public string? Eye { get; set; }

        public string? Hair { get; set; }

        public Wand? Wand { get; set; }
        [JsonIgnore]
        public int? WandId { get; set; }

        public string? Patronus { get; set; }

        public bool IsHogwartsStudent { get; set; }


        public bool IsHogwartsStaff { get; set; }

        public string Actor { get; set; } = default!;

        public bool IsAlive { get; set; }

        public string? ImageUrl { get; set; }
    }
}
