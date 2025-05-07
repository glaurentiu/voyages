using Microsoft.EntityFrameworkCore;
using NapaTraineeAPI.Data;
using NapaTraineeAPI.Models;
using NapaTraineeAPI.Services;
using Xunit;

namespace NapaTraineeAPI.Tests
{
    public class VoyagesServiceTests
    {
        private readonly ApplicationDbContext _context;
        private readonly VoyagesService _service;

        public VoyagesServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            _context = new ApplicationDbContext(options);
            _service = new VoyagesService(_context);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllVoyages()
        {
            // Arrange
            _context.Voyages.Add(new Voyage { ShipId = 1, StartTimestamp = DateTime.Now, EndTimestamp = DateTime.Now, DeparturePortId = 1, ArrivalPortId = 2 });
            _context.Voyages.Add(new Voyage { ShipId = 2, StartTimestamp = DateTime.Now, EndTimestamp = DateTime.Now, DeparturePortId = 2, ArrivalPortId = 1 });
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsVoyage_WhenExists()
        {
            // Arrange
            var voyage = new Voyage { ShipId = 1, StartTimestamp = DateTime.Now, EndTimestamp = DateTime.Now, DeparturePortId = 1, ArrivalPortId = 2 };
            _context.Voyages.Add(voyage);
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.GetByIdAsync(voyage.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.ShipId);
        }
    }
}
