using Microsoft.EntityFrameworkCore;
using NapaTraineeAPI.Data;
using NapaTraineeAPI.Models;
using NapaTraineeAPI.Services;
using Xunit;

namespace NapaTraineeAPI.Tests
{
    public class CountriesServiceTests
    {
        private readonly ApplicationDbContext _context;
        private readonly CountriesService _service;

        public CountriesServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            _context = new ApplicationDbContext(options);
            _service = new CountriesService(_context);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllCountries()
        {
            // Arrange
            _context.Countries.Add(new Country { Name = "Country1" });
            _context.Countries.Add(new Country { Name = "Country2" });
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsCountry_WhenExists()
        {
            // Arrange
            var country = new Country { Name = "Country1" };
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.GetByIdAsync(country.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Country1", result.Name);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNull_WhenNotExists()
        {
            // Act
            var result = await _service.GetByIdAsync(999);

            // Assert
            Assert.Null(result);
        }
    }
}
