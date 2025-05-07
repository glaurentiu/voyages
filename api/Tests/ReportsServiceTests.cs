using Microsoft.EntityFrameworkCore;
using NapaTraineeAPI.Data;
using NapaTraineeAPI.Models;
using NapaTraineeAPI.Services;
using Xunit;

namespace NapaTraineeAPI.Tests
{
    public class ReportsServiceTests
    {
        private readonly ApplicationDbContext _context;
        private readonly ReportsService _service;

        public ReportsServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            _context = new ApplicationDbContext(options);
            _service = new ReportsService(_context);
        }

        [Fact]
        public async Task GetVisitedCountriesLastYearAsync_ReturnsDistinctCountries()
        {
            // Arrange
            var country1 = new Country { Name = "Country1" };
            var country2 = new Country { Name = "Country2" };
            _context.Countries.Add(country1);
            _context.Countries.Add(country2);

            var port1 = new Port { Name = "Port1", Country = country1 };
            var port2 = new Port { Name = "Port2", Country = country2 };
            _context.Ports.Add(port1);
            _context.Ports.Add(port2);

            var ship = new Ship { Name = "Ship1", MaxSpeed = 20.0 };
            _context.Ships.Add(ship);

            _context.Voyages.Add(new Voyage
            {
                Ship = ship,
                StartTimestamp = DateTime.Now.AddMonths(-6),
                EndTimestamp = DateTime.Now.AddMonths(-5),
                DeparturePort = port1,
                ArrivalPort = port2
            });
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.GetVisitedCountriesLastYearAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains("Country1", result);
            Assert.Contains("Country2", result);
        }
    }
}
