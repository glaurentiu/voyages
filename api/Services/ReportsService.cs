using Microsoft.EntityFrameworkCore;
using NapaTraineeAPI.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace NapaTraineeAPI.Services
{
    public class ReportsService : IReportsService
    {
        private readonly ApplicationDbContext _context;

        public ReportsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, int>> GetVisitedCountriesLastYearAsync()
        {
            var oneYearAgo = DateTime.Now.AddYears(-1);

            // Materialize the data
            var voyages = await _context.Voyages
                .Where(voyage => voyage.StartTimestamp >= oneYearAgo)
                .Include(v => v.DeparturePort).ThenInclude(p => p.Country)
                .Include(v => v.ArrivalPort).ThenInclude(p => p.Country)
                .ToListAsync();

            // Count occurrences of each country (no Distinct)
            var countryCounts = voyages
                .SelectMany(voyage => new[]
                {
                    voyage.DeparturePort.Country.Name,
                    voyage.ArrivalPort.Country.Name
                })
                .GroupBy(country => country)
                .ToDictionary(
                    group => group.Key,
                    group => group.Count()
                );

            return countryCounts;
        }
    }
}

