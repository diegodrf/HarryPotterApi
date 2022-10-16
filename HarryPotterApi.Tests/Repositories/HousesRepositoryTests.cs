using HarryPotterApi.Data.Connections;
using HarryPotterApi.Models.Data;
using HarryPotterApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace HarryPotterApi.Tests.Repositories
{
    [TestClass]
    public class HousesRepositoryTests
    {
        [TestMethod]
        public async Task TestMethod()
        {
            var houses = new List<House>()
            {
                new House() {Id = 1, Name ="Gryffindor"},
                new House() {Id = 2, Name ="Slytherin"},
                new House() {Id = 3, Name ="Hufflepuff"},
                new House() {Id = 4, Name ="Ravenclaw"}
            };
            var dbSetMock = new Mock<DbSet<House>>();
            //dbSetMock.Object.AddRange(houses);
            dbSetMock.As<IQueryable<House>>().Setup(m => m.Provider).Returns(houses.AsQueryable().Provider);
            dbSetMock.As<IQueryable<House>>().Setup(m => m.Expression).Returns(houses.AsQueryable().Expression);
            dbSetMock.As<IQueryable<House>>().Setup(m => m.ElementType).Returns(houses.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<House>>().Setup(m => m.GetEnumerator()).Returns(houses.AsQueryable().GetEnumerator());


            var dbContextMock = new Mock<HarryPotterApiDbContext>(new DbContextOptions<HarryPotterApiDbContext>());
            dbContextMock.Object.Houses.AddRange(houses);
            
           
            var houseRepository = new HousesRepository(dbContextMock.Object);

            var _ = await houseRepository.GetAllAsync(0, 10);
            Assert.AreEqual(4, _.Count());
            
        }
    }
}
