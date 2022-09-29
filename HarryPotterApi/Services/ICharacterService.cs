using HarryPotterApi.Models.Data;

namespace HarryPotterApi.Services
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAll(int skip, int take);
        Task<int> GetAllCount();
    }
}
