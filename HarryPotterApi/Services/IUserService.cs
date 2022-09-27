using Api.Models.Data;

namespace Api.Services;

public interface IUserService
{
    Task<User> GetByUserNameAsync(string username);
    Task<User> GetByIdAsync(Guid id);
}