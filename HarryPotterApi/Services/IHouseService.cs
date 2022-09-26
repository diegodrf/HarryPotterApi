using Api.Models.Data;

namespace Api.Services;

public interface IHouseService
{
    Task<List<House>> GetAll();
    Task<House> GetById(int id);
    
    Task<List<Character>> GetCharacters(int houseId, int skip, int take);
    Task<int> GetCharactersCount(int houseId);
}