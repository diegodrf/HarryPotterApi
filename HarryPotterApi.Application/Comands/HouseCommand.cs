using HarryPotterApi.Domain.ValueObjects;

namespace HarryPotterApi.Application.Comands
{
    public class HouseCommand : ICommand
    {
        public HouseCommand(int page, int? houseId = null)
        {
            Page = page;
            HouseId = houseId;
        }
        public int Page { get; set; }
        public int? HouseId { get; set; }
    }
}