using Microsoft.EntityFrameworkCore;
using NapaTraineeAPI.Data;
using NapaTraineeAPI.Models;

namespace NapaTraineeAPI.Services
{
    public class ShipsService : IShipsService
    {
        private readonly ApplicationDbContext _context;

        public ShipsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ship>> GetAllAsync()
        {
            return await _context.Ships.ToListAsync();
        }

        public async Task<Ship> GetByIdAsync(int id)
        {
            return await _context.Ships.FindAsync(id);
        }
    }
}
