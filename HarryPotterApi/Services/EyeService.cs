using Api.Data.Connections;
using Api.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class EyeService : IEyeService
    {
        private readonly HarryPotterApiDbContext _context;
        public EyeService(HarryPotterApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Eye>> GetAll()
        {
            return await _context.Eyes.ToListAsync();
        }
    }
}
