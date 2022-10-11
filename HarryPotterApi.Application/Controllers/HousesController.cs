using HarryPotterApi.Application.Comands;
using HarryPotterApi.Application.Handlers;
using HarryPotterApi.Domain.Entities;
using HarryPotterApi.Infrastructure.Repositories;
using HarryPotterApi.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace HarryPotterApi.Application.Controllers
{
    [Route("api/houses")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly ILogger<HousesController> _logger;
        private readonly IHouseRepository _houseRepository;
        private readonly IPaginationService _paginationService;

        public HousesController(
            ILogger<HousesController> logger,
            IHouseRepository houseRepository,
            IPaginationService paginationService)
        {
            _logger = logger;
            _houseRepository = houseRepository;
            _paginationService = paginationService;
        }

        [HttpGet]
        public async Task<ActionResult> GetHouses([FromQuery] int page = 1)
        {
            var command = new HouseCommand(page);
            var houseHandler = new HouseHandler(_houseRepository, _paginationService);
            var response = await houseHandler.AllHousesHandle(command);
            return Ok(response);
        }

        [HttpGet("Houses/{id:int}/Characters")]
        public async Task<ActionResult> GetCharactersByHouse(int id, [FromQuery] int page = 1)
        {
            var command = new HouseCommand(page, id);
            var houseHandler = new HouseHandler(_houseRepository, _paginationService);
            var response = await houseHandler.CharactersByHouseHandle(command);
            return Ok(response);
        }
    }
}