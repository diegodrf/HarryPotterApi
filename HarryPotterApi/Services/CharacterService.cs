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
        public async Task<List<Character>> GetAll(int skip, int take)
        {
            return await _context.Characters
                .Include(i => i.House)
                .Include(i => i.Species)
                .Include(i => i.Gender)
                .Include(i => i.Wand)
                .OrderBy(i => i.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<int> GetAllCount()
        {
            return await _context.Characters.CountAsync();
        }
    }
}
