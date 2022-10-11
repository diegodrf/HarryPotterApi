
using HarryPotterApi.Application.Comands;
using HarryPotterApi.Domain.Entities;
using HarryPotterApi.Domain.ValueObjects;
using HarryPotterApi.Infrastructure.Repositories;
using HarryPotterApi.Infrastructure.Services;

namespace HarryPotterApi.Application.Handlers
{
    public class HouseHandler : IHouseHandler
    {
        private IHouseRepository _houseRepository;
        private IPaginationService _paginationService;

        public HouseHandler(IHouseRepository houseRepository, IPaginationService paginationService)
        {
            _houseRepository = houseRepository;
            _paginationService = paginationService;

        }
        public async Task<ICommandResult> AllHousesHandle(HouseCommand command)
        {
            var skip = _paginationService.SkipCalculator(command.Page);
            var take = _paginationService.ItemsPerPage;

            var pagination = new Pagination(skip, take);

            var houses = await _houseRepository.GetAllAsync(pagination);
            var totalOfItems = await _houseRepository.CountAllAsync();

            var pages = _paginationService.PagesTotal(totalOfItems);

            var commandResult = new CommandResult<House>(pages, command.Page, houses);

            return commandResult;
        }

        public async Task<ICommandResult> CharactersByHouseHandle(HouseCommand command)
        {
            var skip = _paginationService.SkipCalculator(command.Page);
            var take = _paginationService.ItemsPerPage;

            var pagination = new Pagination(skip, take);

            var characters = await _houseRepository.GetCharactertsByHouseIdAsync(command?.HouseId ?? 0, pagination);
            var totalOfItems = await _houseRepository.CountAllAsync();

            var pages = _paginationService.PagesTotal(totalOfItems);

            var commandResult = new CommandResult<Character>(pages, command!.Page, characters);

            return commandResult;
        }
    }
}