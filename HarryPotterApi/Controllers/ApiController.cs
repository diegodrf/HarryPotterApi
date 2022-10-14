using HarryPotterApi.Models;
using HarryPotterApi.Models.Data;
using HarryPotterApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

    [SwaggerOperation(Summary = "Get all houses", Tags = new[] { "Houses" })]
    [HttpGet("Houses")]
    public async Task<IEnumerable<House>> GetHouses()
    {
        return await _houseService.GetAllAsync();
    }

    [SwaggerOperation(
        Summary = "Get all characters from house",
        Description = "This endpoint uses a paginated query.",
        Tags = new[] { "Houses", "Characters" })
    ]
    [HttpGet("Houses/{id:int}/Characters")]
    public async Task<PaginatedResponseModel<Character>> GetCharactersByHouse([FromRoute] int id, [FromQuery] int page = 1)
    {
        const int take = 25;
        var skip = take * (page - 1);
        var total = await _houseService.GetCharactersCountAsync(id);
        var pages = total / take;
        if (total % take > 0)
        {
            pages += 1;
        }
        var items = await _houseService.GetCharactersAsync(id, skip, take);
        return new PaginatedResponseModel<Character>(pages, page, items);
    }
}