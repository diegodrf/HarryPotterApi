using Api.Data.Connections;
using Api.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly HarryPotterApiDbContext _context;
        public CharacterService(HarryPotterApiDbContext context)
        {
            _context = context;
        }
        public async Task<List<Character>> GetAll()
        {
            return await _context.Characters
                .Include(i => i.House)
                .Include(i => i.Species)
                .Include(i => i.Gender)
                .Include(i => i.Wand)
                .ToListAsync();
        }
    }
}
