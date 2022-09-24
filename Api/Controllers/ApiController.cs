using Api.Models.Data;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public ApiController(
            ICharacterService characterService
            )
        {
            _characterService = characterService;
        }

        [HttpGet("Characters")]
        public async Task<IEnumerable<Character>> GetCharacters()
        {
            return await _characterService.GetAll();
        }
    }
}
