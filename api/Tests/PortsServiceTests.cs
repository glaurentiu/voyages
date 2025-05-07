using Microsoft.EntityFrameworkCore;
using NapaTraineeAPI.Data;
using NapaTraineeAPI.Models;
using NapaTraineeAPI.Services;
using Xunit;

namespace NapaTraineeAPI.Tests
{
    public class PortsServiceTests
    {
        private readonly ApplicationDbContext _context;
        private readonly PortsService _service;

        public PortsServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            _context = new ApplicationDbContext(options);
            _service = new PortsService(_context);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllPorts()
        {
            // Arrange
            _context.Ports.Add(new Port { Name = "Port1", CountryId = 1 });
            _context.Ports.Add(new Port { Name = "Port2", CountryId = 2 });
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsPort_WhenExists()
        {
            // Arrange
            var port = new Port { Name = "Port1", CountryId = 1 };
            _context.Ports.Add(port);
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.GetByIdAsync(port.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Port1", result.Name);
        }
    }
}
