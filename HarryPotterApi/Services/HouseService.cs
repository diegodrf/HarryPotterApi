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
}
