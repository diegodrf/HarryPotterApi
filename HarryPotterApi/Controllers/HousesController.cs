using HarryPotterApi.Models.Data;
using HarryPotterApi.Models;
using HarryPotterApi.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using HarryPotterApi.Repositories.contracts;

namespace HarryPotterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController: ControllerBase
    {
        private readonly IPaginatorService _paginatorService;
        private readonly IHousesRepository _houseService;
        public HousesController(
            IPaginatorService paginatorService,
            IHousesRepository houseService
            )
        {
            _paginatorService = paginatorService ?? throw new ArgumentNullException(nameof(paginatorService));
            _houseService = houseService ?? throw new ArgumentNullException(nameof(houseService));
        }

        [SwaggerOperation(Summary = "Get all houses", Tags = new[] { "Houses" })]
        [HttpGet]
        public async Task<PaginatedResponseModel<House>> GetHouses([FromQuery] int page=1)
        {
            var total = await _houseService.GetAllCountAsync();
            var paginator = _paginatorService.Paginate(page, total);
            var items = await _houseService.GetAllAsync(paginator.Skip, paginator.Take);
            return new PaginatedResponseModel<House>(
                paginator.TotalPages,
                paginator.Page,
                items
                );
        }

        [SwaggerOperation(
            Summary = "Get all characters from house",
            Description = "This endpoint uses a paginated query.",
            Tags = new[] { "Houses", "Characters" })]
        [HttpGet]
        [Route("{id:int}/Characters")]
        public async Task<PaginatedResponseModel<Character>> GetCharactersByHouse([FromRoute] int id, [FromQuery] int page = 1)
        {
            var total = await _houseService.GetCharactersCountAsync(id);
            var paginator = _paginatorService.Paginate(page, total);
            var items = await _houseService.GetCharactersAsync(id, paginator.Skip, paginator.Take);
            return new PaginatedResponseModel<Character>(
                paginator.TotalPages, 
                paginator.Page, 
                items);
        }
    }
}
