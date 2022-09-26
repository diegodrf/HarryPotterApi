using Api.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Connections
{
    public class HarryPotterApiDbContext: DbContext
    {
        

        public HarryPotterApiDbContext(DbContextOptions<HarryPotterApiDbContext> options) : base(options)
        {
            // https://stackoverflow.com/questions/69961449/net6-and-datetime-problem-cannot-write-datetime-with-kind-utc-to-postgresql-ty
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        // public DbSet<Eye> Eyes { get; set;  } = default!;
        public DbSet<Gender> Genders { get; set; } = default!;
        // public DbSet<Hair> Hairs { get; set; } = default!;
        public DbSet<House> Houses { get; set; } = default!;
        public DbSet<Species> Species { get; set; } = default!;
        public DbSet<Wand> Wands { get; set; } = default!;
        public DbSet<Character> Characters { get; set; } = default!;
    }
}
