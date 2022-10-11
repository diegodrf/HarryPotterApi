using System;
using HarryPotterApi.Domain.Entities;
using HarryPotterApi.Domain.ValueObjects;

namespace HarryPotterApi.Infrastructure.Repositories
{
    public interface IHouseRepository
    {
        Task<IEnumerable<House>> GetAllAsync(Pagination pagination);
        Task<int> CountAllAsync();
        Task<IEnumerable<Character>> GetCharactertsByHouseIdAsync(int id, Pagination pagination);
    }
}