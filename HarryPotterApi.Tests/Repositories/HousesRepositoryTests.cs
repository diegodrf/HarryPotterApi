using HarryPotterApi.Data.Connections;
using HarryPotterApi.Repositories;
using HarryPotterApi.Services;
using Microsoft.EntityFrameworkCore;

namespace HarryPotterApi.Tests.Repositories
{
    [TestClass]
    public class HousesRepositoryTests
    {
        private readonly Uri _imagesBaseUrl;
        private readonly Uri _charactersDataSource;
        private readonly HarryPotterApiDbContext _dbContext;


        public HousesRepositoryTests()
        {
            _imagesBaseUrl = new Uri("https://raw.githubusercontent.com/diegodrf/HarryPotterApi/main/Assets/Images/");
            _charactersDataSource = new Uri("https://github.com/diegodrf/HarryPotterApi/main/Assets/characters.json");

            var options = new DbContextOptionsBuilder<HarryPotterApiDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _dbContext = new HarryPotterApiDbContext(options);
            
        }

        [TestInitialize]
        public async Task TearUp()
        {
            var dataSeeding = new DataSeedingService(_dbContext, _imagesBaseUrl, _charactersDataSource);
            await dataSeeding.Run();
        }

        [TestCleanup]
        public void TearDown()
        {

        }


        [TestMethod]
        public async Task TestMethod()
        {

            var houseRepository = new HousesRepository(_dbContext);

            var _ = await houseRepository.GetAllAsync(0, 10);
            Assert.AreEqual(4, _.Count());

        }
    }
}
