using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarryPotterApi.Infrastructure.Services
{
    public interface IPaginationService
    {
        int ItemsPerPage { get; }
        int PagesTotal(int totalOfItemsInDataSource);
        int SkipCalculator(int page);
    }
}