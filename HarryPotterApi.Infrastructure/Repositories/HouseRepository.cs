using HarryPotterApi.Domain.Entities;
using HarryPotterApi.Domain.ValueObjects;
using HarryPotterApi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace HarryPotterApi.Infrastructure.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly HarryPotterApiDbContext _context;
        public HouseRepository(HarryPotterApiDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountAllAsync()
        {
            return await _context.Houses.AsNoTracking().CountAsync();
        }

        public async Task<IEnumerable<House>> GetAllAsync(Pagination pagination)
        {
            return await _context.Houses
                .AsNoTracking()
                .OrderBy(_ => _.Id)
                .Skip(pagination.Skip)
                .Take(pagination.Take)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Character>> GetCharactertsByHouseIdAsync(int id, Pagination pagination)
        {
            return await _context.Characters
                .AsNoTracking()
                .Where(_ => _.HouseId == id)
                .OrderBy(_ => _.Id)
                .Skip(pagination.Skip)
                .Take(pagination.Take)
                .Include(_ => _.Wand)
                .Include(_ => _.Species)
                .Include(_ => _.Gender)
                .Include(_ => _.House)
                .ToArrayAsync();
        }
    }
}