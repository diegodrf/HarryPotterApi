using Api.Models.Data;

namespace Api.Services;

public interface IJwtService
{
    string GenerateToken(User user);
}