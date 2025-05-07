using Microsoft.EntityFrameworkCore;
using NapaTraineeAPI.Data;
using NapaTraineeAPI.Models;

namespace NapaTraineeAPI.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly ApplicationDbContext _context;

        public CountriesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await _context.Countries.FindAsync(id);
        }
    }
}
