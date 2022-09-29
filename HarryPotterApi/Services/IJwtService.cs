using HarryPotterApi.Models.Data;

namespace HarryPotterApi.Services;

public interface IJwtService
{
    string GenerateToken(User user);
}