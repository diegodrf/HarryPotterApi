using HarryPotterApi.Models.Data;

namespace HarryPotterApi.Services;

public interface IUserService
{
    Task<User> GetByUserNameAsync(string username);
    Task<User> GetByIdAsync(Guid id);
}