using HarryPotterApi.Models.Data;

namespace HarryPotterApi.Services
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAllAsync(int skip, int take);
        Task<int> GetAllCountAsync();
    }
}
