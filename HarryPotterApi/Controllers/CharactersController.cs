using HarryPotterApi.Models.Data;
using HarryPotterApi.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using HarryPotterApi.Services.Contracts;

namespace HarryPotterApi.Controllers
{
    [Route("api/characters")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly IPaginatorService _paginatorService;
        private readonly ICharacterService _characterService;
        public CharactersController(
            IPaginatorService paginatorService,
            ICharacterService characterService
            )
        {
            _paginatorService = paginatorService ?? throw new ArgumentNullException(nameof(paginatorService));
            _characterService = characterService ?? throw new ArgumentNullException(nameof(characterService));
        }

        [SwaggerOperation(
        Summary = "Get all characters",
        Description = "This endpoint uses a paginated query.",
        Tags = new[] { "Characters" })]
        [HttpGet]
        public async Task<PaginatedResponseModel<Character>> GetCharacters([FromQuery] int page = 1)
        {
            var total = await _characterService.GetAllCountAsync();
            var paginator = _paginatorService.Paginate(page, total);
            var items = await _characterService.GetAllAsync(paginator.Skip, paginator.Take);

            return new PaginatedResponseModel<Character>(
                paginator.TotalPages, 
                paginator.Page, 
                items);          
        }
    }
}
