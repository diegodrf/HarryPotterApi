using Microsoft.Extensions.Configuration;

namespace HarryPotterApi.Infrastructure.Services
{
    public class PaginationService : IPaginationService
    {

        private int _itemsPerPage;
        public PaginationService(IConfiguration configuration)
        {
            var _ = configuration["ItemsPerPage"] ?? throw new ArgumentNullException();
            _itemsPerPage = int.Parse(_);
        }

        public int ItemsPerPage => _itemsPerPage;

        public int PagesTotal(int totalOfItemsInDataSource)
        {
            var pages = totalOfItemsInDataSource / ItemsPerPage;
            if (totalOfItemsInDataSource % ItemsPerPage > 0)
            {
                pages += 1;
            }


            return pages;
        }

        public int SkipCalculator(int page)
        {
            return (ItemsPerPage * page) - ItemsPerPage;
        }
    }
}