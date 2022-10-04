using HarryPotterApi.Data.Connections;
using HarryPotterApi.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace HarryPotterApi.Services;


public class HouseService : IHouseService
{
    private readonly HarryPotterApiDbContext _context;
    public HouseService(HarryPotterApiDbContext context)
    {
        _context = context;
    }
    public async Task<List<House>> GetAllAsync()
    {
        return await _context.Houses.ToListAsync();

    }

    public Task<House> GetByIdAsync(int id)
    {
        // TODO implement get house by id
        throw new NotImplementedException();
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
