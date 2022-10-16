using HarryPotterApi.Models;

namespace HarryPotterApi.Services.Contracts
{
    public interface IPaginatorService
    {
        Paginator Paginate(int page, int totalNumberOfItemsInDataSource);
        int TotalPages(int page, int totalNumberOfItemsInDataSource);
        int Skip(int page, int itemsPerPage);
    }
}
