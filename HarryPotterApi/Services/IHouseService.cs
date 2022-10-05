using HarryPotterApi.Models.Data;

namespace HarryPotterApi.Services;

public interface IHouseService
{
    Task<List<House>> GetAllAsync();
    
    Task<List<Character>> GetCharactersAsync(int houseId, int skip, int take);
    Task<int> GetCharactersCountAsync(int houseId);
}