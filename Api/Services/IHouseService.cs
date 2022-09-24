using Api.Models.Data;

namespace Api.Services;

public interface IHouseService
{
    Task<List<House>> GetAll();
    Task<House> GetById(int id);
}