using Api.Models.Data;

namespace Api.Services
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAll();
    }
}
