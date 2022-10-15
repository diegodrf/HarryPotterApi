using HarryPotterApi.Data.Connections;
using HarryPotterApi.Models.Data;
using HarryPotterApi.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HarryPotterApi.Services;


public class HouseService : IHouseService
{
    private readonly HarryPotterApiDbContext _context;
    public HouseService(HarryPotterApiDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<IEnumerable<House>> GetAllAsync(int skip, int take)
    {
        return await _context.Houses
            .AsNoTracking()
            .OrderBy(_ => _.Id)
            .Skip(skip)
            .Take(take)
            .ToArrayAsync();
    }

    public async Task<int> GetAllCountAsync()
    {
        return await _context.Houses.AsNoTracking().CountAsync();
    }

    public async Task<List<Character>> GetCharactersAsync(int houseId, int skip, int take)
    {
        return await _context.Characters
            .AsNoTracking()
            .Include(i => i.House)
            .Include(i => i.Species)
            .Include(i => i.Gender)
            .Include(i => i.Wand)
            .Where(i => i.HouseId == houseId)
            .OrderBy(i => i.Id)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<int> GetCharactersCountAsync(int houseId)
    {
        return await _context.Characters
            .AsNoTracking()
            .Where(i => i.HouseId == houseId)
            .CountAsync();
    }
}
