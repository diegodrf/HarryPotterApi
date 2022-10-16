using HarryPotterApi.Models.Data;

namespace HarryPotterApi.Repositories.contracts
{
    public interface ICharactersRepository
    {
        Task<List<Character>> GetAllAsync(int skip, int take);
        Task<int> GetAllCountAsync();
    }
}
