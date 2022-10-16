using HarryPotterApi.Constants;
using HarryPotterApi.Data.Connections;
using HarryPotterApi.Models.Data;
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
        private HarryPotterApiDbContext? _dbContext;


        public HousesRepositoryTests()
        {
            _imagesBaseUrl = new Uri("https://raw.githubusercontent.com/diegodrf/HarryPotterApi/main/Assets/Images/");
            _charactersDataSource = new Uri("https://raw.githubusercontent.com/diegodrf/HarryPotterApi/main/Assets/characters.json");
        }

        [TestInitialize]
        public async Task TearUp()
        {
            var options = new DbContextOptionsBuilder<HarryPotterApiDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _dbContext = new HarryPotterApiDbContext(options);

            var dataSeeding = new DataSeedingService(_dbContext, _imagesBaseUrl, _charactersDataSource);
            await dataSeeding.Run();
        }

        [TestCleanup]
        public void TearDown()
        {

        }


        [TestMethod]
        public async Task Should_Return_4_Houses()
        {
            var houseRepository = new HousesRepository(_dbContext!);

            var _ = await houseRepository.GetAllAsync(0, 10);
            Assert.AreEqual(4, _.Count());
        }

        [TestMethod]
        public async Task Should_Return_Characters_From_House()
        {
            var houseRepository = new HousesRepository(_dbContext!);

            var characters = await houseRepository.GetCharactersAsync(1, 0, 25);
            
            Assert.AreEqual(typeof(List<Character>), characters.GetType());
            Assert.IsTrue(characters.Count > 0);
        }

        [TestMethod]
        public async Task Should_Return_Total_Of_Houses()
        {
            var houseRepository = new HousesRepository(_dbContext!);

            var housesQuantity = await houseRepository.GetAllCountAsync();
            Assert.IsTrue(housesQuantity > 0);
        }

        [TestMethod]
        public async Task Should_Return_Total_Of_Characters_From_Houses()
        {
            var houseRepository = new HousesRepository(_dbContext!);

            var charactersQuantity = await houseRepository.GetCharactersCountAsync(1);
            Assert.IsTrue(charactersQuantity > 0);
        }

        [TestMethod]
        public async Task Should_Return_Zero_Characters_From_Houses()
        {
            var houseRepository = new HousesRepository(_dbContext!);

            var characters = await houseRepository.GetCharactersAsync(1000, 0, 100);
            Assert.AreEqual(typeof(List<Character>), characters.GetType());
            Assert.IsTrue(characters.Count == 0);
        }
    }
}
