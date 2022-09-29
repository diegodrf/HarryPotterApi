using HarryPotterApi.Models.Data;
using HarryPotterApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HarryPotterApi.Controllers;

[Route("api")]
[ApiController]
public class ApiController : ControllerBase
{
    private readonly ILogger<ApiController> _logger;
    private readonly ICharacterService _characterService;
    private readonly IHouseService _houseService;
    public ApiController(
        ILogger<ApiController> logger,
        ICharacterService characterService,
        IHouseService houseService
    )
    {
        _logger = logger;
        _characterService = characterService;
        _houseService = houseService;
    }
        
    [HttpGet("Characters")]
    public async Task<IActionResult> GetCharacters([FromQuery] int page = 1)
    {
        try
        {
            const int take = 25;
            var skip = take * (page - 1);
            var total = await _characterService.GetAllCount();
            var pages = total / take;
            if (total % take > 0)
            {
                pages += 1;
            }
            var items = await _characterService.GetAll(skip, take);

            return Ok(new
            {
                totalPages = pages,
                currentPage = page,
                items = items.Count,
                data = items
            });
        }
        catch (Exception e)
        {
            _logger.LogCritical(e.Message);
            throw;
        }
    }

    [HttpGet("Houses")]
    public async Task<IEnumerable<House>> GetHouses()
    {
        return await _houseService.GetAll();
    }
        
    [HttpGet("Houses/{id:int}/Characters")]
    public async Task<IActionResult> GetCharactersByHouse([FromRoute] int id, [FromQuery] int page = 1)
    {
        const int take = 25;
        var skip = take * (page - 1);
        var total = await _houseService.GetCharactersCount(id);
        var pages = total / take;
        if (total % take > 0)
        {
            pages += 1;
        }
        var items = await _houseService.GetCharacters(id, skip, take);

        return Ok(new
        {
            totalPages = pages,
            currentPage = page,
            items = items.Count,
            data = items
        });
    }

    [HttpGet("authenticated")]
    [Authorize]
    public string Authenticated()
    {
        return $"Hello World! Authenticated! {User.Identity?.Name}"; 
    } 
}