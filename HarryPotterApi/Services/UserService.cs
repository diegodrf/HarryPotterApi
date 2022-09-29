using HarryPotterApi.Data.Connections;
using HarryPotterApi.Models.Data;
using HarryPotterApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HarryPotterApi.Services;

public class UserService: IUserService
{
    private readonly HarryPotterApiDbContext _context;

    public UserService(HarryPotterApiDbContext context)
    {
        _context = context;
    }


    public async Task<User> GetByUserNameAsync(string username)
    {
        try
        {
            return await _context.Users
                .SingleAsync(e => e.Username.Equals(
                    username, 
                    StringComparison.InvariantCultureIgnoreCase
                    )
                );
        }
        catch (InvalidOperationException e)
        {
            throw new NotFoundException(e.Message);
        }
        
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        try
        {
            return await _context.Users
                .SingleAsync(e => e.Id.Equals(id));
        }
        catch (InvalidOperationException e)
        {
            throw new NotFoundException(e.Message);
        }
    }
}