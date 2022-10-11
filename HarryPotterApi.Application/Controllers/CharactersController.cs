using Microsoft.AspNetCore.Mvc;

namespace HarryPotterApi.Application.Controllers
{
    [Route("api/characters")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ILogger<CharactersController> _logger;

        public CharactersController(ILogger<CharactersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Task<ActionResult> GetCharacters()
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}