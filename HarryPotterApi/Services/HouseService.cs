using Api.Data.Connections;
using Api.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;


public class HouseService : IHouseService
{
    private readonly HarryPotterApiDbContext _context;
    public HouseService(HarryPotterApiDbContext context)
    {
        _context = context;
    }
    public async Task<List<House>> GetAll()
    {
        return await _context.Houses.ToListAsync();

    }

    public Task<House> GetById(int id)
    {
        // TODO implement get house by id
        throw new NotImplementedException();
    }

    public async Task<List<Character>> GetCharacters(int houseId, int skip, int take)
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

    public async Task<int> GetCharactersCount(int houseId)
    {
        return await _context.Characters
            .AsNoTracking()
            .Where(i => i.HouseId == houseId)
            .CountAsync();
    }
}
