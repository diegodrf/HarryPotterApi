using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarryPotterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HarryPotterApi.Infrastructure.Database
{
    public class HarryPotterApiDbContext : DbContext
    {
        public HarryPotterApiDbContext(DbContextOptions<HarryPotterApiDbContext> options) : base(options)
        {
            // https://stackoverflow.com/questions/69961449/net6-and-datetime-problem-cannot-write-datetime-with-kind-utc-to-postgresql-ty
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<Gender> Genders { get; set; } = default!;
        public DbSet<House> Houses { get; set; } = default!;
        public DbSet<Species> Species { get; set; } = default!;
        public DbSet<Wand> Wands { get; set; } = default!;
        public DbSet<Character> Characters { get; set; } = default!;
    }
}