using Api.Models.Data;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IHouseService _houseService;
        public ApiController(
            ICharacterService characterService,
            IHouseService houseService
            )
        {
            _characterService = characterService;
            _houseService = houseService;
        }

        [HttpGet("Characters")]
        public async Task<IEnumerable<Character>> GetCharacters()
        {
            return await _characterService.GetAll();
        }

        [HttpGet("Houses")]
        public async Task<IEnumerable<House>> GetHouses()
        {
            return await _houseService.GetAll();
        }
    }
}
