using HarryPotterApi.Constants;
using HarryPotterApi.Services;
using HarryPotterApi.ValueObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HarryPotterApi.Tests.Services
{
    [TestClass]
    public class PaginatorServiceTests
    {
        private readonly IConfiguration _configuration;

        public PaginatorServiceTests()
        {            
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.tests.json")
                .Build();
        }

        [TestMethod]
        public void Should_Return_ItemsPerPage_Equals_25()
        {
            var itemsPerPage = _configuration
                .GetRequiredSection(ConfigurationConstants.Pagination)
                .GetValue<int>(ConfigurationConstants.ItemsPerPage);
            Assert.AreEqual(25, itemsPerPage);
        }
        [TestMethod]
        public void Should_Return_An_Paginator_Object()
        {
            var paginatorSerice = new PaginatorService(_configuration);
            var paginator = paginatorSerice.Paginate(1, 10);
            Assert.AreEqual(typeof(Paginator), paginator.GetType());
        }
        [TestMethod]
        [DataTestMethod]
        [DataRow(1, 25, 0)]
        [DataRow(2, 10, 10)]
        [DataRow(10, 1000, 9000)]
        [DataRow(7, 11, 66)]
        public void Skip_Should_Return_ExpectedValue(int page, int itemsPerPage, int expectedValue)
        {
            var paginatorSerice = new PaginatorService(_configuration);
            var skip = paginatorSerice.Skip(page, itemsPerPage);
            Assert.AreEqual(expectedValue, skip);
        }
        [TestMethod]
        [DataTestMethod]
        [DataRow(25, 100, 4)]
        [DataRow(10, 100, 10)]
        [DataRow(5, 200, 40)]
        [DataRow(33, 100, 4)]
        public void TotalPages_Should_Return_ExpectedValue(int itemsPerPage, int totalNumberOfItemsInDataSource, int expectedValue)
        {
            var paginatorSerice = new PaginatorService(_configuration);
            var totalPages = paginatorSerice.TotalPages(itemsPerPage, totalNumberOfItemsInDataSource);
            Assert.AreEqual(expectedValue, totalPages);
        }
        [TestMethod]
        [DataTestMethod]
        [DataRow(1, 100, 0, 25, 1, 4)]
        [DataRow(3, 150, 50, 25, 3, 6)]
        public void Paginate_Should_Return_Paginator_Object_with_ExpectedValue(
            int page, 
            int totalNumberOfItemsInDataSource,
            int expectedSkip, 
            int expectedTake, 
            int expectedPage, 
            int expectedTotalPages
            )
        {
            // TODO: Refactor to accpet variable ItemsPerPage
            var paginatorSerice = new PaginatorService(_configuration);
            var paginator = paginatorSerice.Paginate(page, totalNumberOfItemsInDataSource);
            
            Assert.AreEqual(expectedSkip, paginator.Skip);
            Assert.AreEqual(expectedTake, paginator.Take);
            Assert.AreEqual(expectedPage, paginator.Page);
            Assert.AreEqual(expectedTotalPages, paginator.TotalPages);
        }
    }
}
