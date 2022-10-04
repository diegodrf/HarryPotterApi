using HarryPotterApi.Data.Connections;
using HarryPotterApi.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace HarryPotterApi.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly HarryPotterApiDbContext _context;
        public CharacterService(HarryPotterApiDbContext context)
        {
            _context = context;
        }
        public async Task<List<Character>> GetAllAsync(int skip, int take)
        {
            return await _context.Characters
                .AsNoTracking()
                .Include(i => i.House)
                .Include(i => i.Species)
                .Include(i => i.Gender)
                .Include(i => i.Wand)
                .OrderBy(i => i.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<int> GetAllCountAsync()
        {
            return await _context.Characters.AsNoTracking().CountAsync();
        }
    }
}
