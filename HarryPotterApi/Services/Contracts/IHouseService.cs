using HarryPotterApi.Models.Data;

namespace HarryPotterApi.Services.Contracts;

public interface IHouseService
{
    Task<IEnumerable<House>> GetAllAsync(int skip, int take);
    Task<int> GetAllCountAsync();

    Task<List<Character>> GetCharactersAsync(int houseId, int skip, int take);
    Task<int> GetCharactersCountAsync(int houseId);
}