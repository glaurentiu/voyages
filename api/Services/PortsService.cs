using Microsoft.EntityFrameworkCore;
using NapaTraineeAPI.Data;
using NapaTraineeAPI.Models;

namespace NapaTraineeAPI.Services
{
    public class PortsService : IPortsService
    {
        private readonly ApplicationDbContext _context;

        public PortsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Port>> GetAllAsync()
        {
            return await _context.Ports.ToListAsync();
        }

        public async Task<Port> GetByIdAsync(int id)
        {
            return await _context.Ports.FindAsync(id);
        }
    }
}
