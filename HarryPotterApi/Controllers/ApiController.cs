using Api.Models.Data;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
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
        public async Task<IEnumerable<Character>> GetCharacters()
        {
            try
            {
                return await _characterService.GetAll();
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
    }
}
