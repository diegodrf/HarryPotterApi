using HarryPotterApi.Models;
using HarryPotterApi.Services.Contracts;

namespace HarryPotterApi.Services
{
    public class PaginatorService : IPaginatorService
    {
        public int ItemsPerPage { get; private set; }

        public PaginatorService(int itemsPerPage)
        {
            ItemsPerPage = itemsPerPage;
        }

        public Paginator Paginate(int page, int totalNumberOfItemsInDataSource)
        {
            var totalPages = TotalPages(ItemsPerPage, totalNumberOfItemsInDataSource);
            var skip = Skip(page, ItemsPerPage);

            return new Paginator(skip, ItemsPerPage, page, totalPages);
        }

        public int TotalPages(int itemsPerPage, int totalNumberOfItemsInDataSource)
        {
            var totalPages = totalNumberOfItemsInDataSource / itemsPerPage;
            if (totalNumberOfItemsInDataSource % itemsPerPage > 0)
            {
                totalPages++;
            }
            return totalPages;

        }

        public int Skip(int page, int itemsPerPage)
        {
            return itemsPerPage * (page - 1);
        }
    }
}
