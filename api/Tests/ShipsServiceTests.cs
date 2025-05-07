using Microsoft.EntityFrameworkCore;
using NapaTraineeAPI.Data;
using NapaTraineeAPI.Models;
using NapaTraineeAPI.Services;
using Xunit;

namespace NapaTraineeAPI.Tests
{
    public class ShipsServiceTests
    {
        private readonly ApplicationDbContext _context;
        private readonly ShipsService _service;

        public ShipsServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            _context = new ApplicationDbContext(options);
            _service = new ShipsService(_context);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllShips()
        {
            // Arrange
            _context.Ships.Add(new Ship { Name = "Ship1", MaxSpeed = 20.0 });
            _context.Ships.Add(new Ship { Name = "Ship2", MaxSpeed = 25.0 });
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsShip_WhenExists()
        {
            // Arrange
            var ship = new Ship { Name = "Ship1", MaxSpeed = 20.0 };
            _context.Ships.Add(ship);
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.GetByIdAsync(ship.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Ship1", result.Name);
        }
    }
}
