using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Connections
{
    public class HarryPotterApiDbContext : DbContext
    {
        public HarryPotterApiDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
