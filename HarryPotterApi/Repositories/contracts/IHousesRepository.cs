using HarryPotterApi.Models.Data;

namespace HarryPotterApi.Repositories.contracts
{
    public interface IHousesRepository
    {
        Task<IEnumerable<House>> GetAllAsync(int skip, int take);
        Task<int> GetAllCountAsync();

        Task<List<Character>> GetCharactersAsync(int houseId, int skip, int take);
        Task<int> GetCharactersCountAsync(int houseId);
    }
}
