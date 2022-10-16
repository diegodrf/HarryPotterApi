using HarryPotterApi.Data.Connections;
using HarryPotterApi.Models.Data;
using HarryPotterApi.Repositories.contracts;
using Microsoft.EntityFrameworkCore;

namespace HarryPotterApi.Repositories
{
    public class CharactersRepository : ICharactersRepository
    {
        private readonly HarryPotterApiDbContext _context;
        public CharactersRepository(HarryPotterApiDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
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
