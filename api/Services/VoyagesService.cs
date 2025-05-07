using Microsoft.EntityFrameworkCore;
using NapaTraineeAPI.Data;
using NapaTraineeAPI.Models;

namespace NapaTraineeAPI.Services
{
    public class VoyagesService : IVoyagesService
    {
        private readonly ApplicationDbContext _context;

        public VoyagesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VoyageDto>> GetAllAsync()
        {
            return await _context.Voyages
               .Include(v => v.Ship)
               .Include(v => v.DeparturePort)
                   .ThenInclude(p => p.Country)
               .Include(v => v.ArrivalPort)
                   .ThenInclude(p => p.Country)
               .Select(v => new VoyageDto
               {
                   Id = v.Id,
                   ShipId = v.ShipId,
                   ShipName = v.Ship.Name,
                   ShipMaxSpeed = v.Ship.MaxSpeed,
                   DeparturePortId = v.DeparturePortId,
                   DeparturePortName = v.DeparturePort.Name,
                   DepartureCountryName = v.DeparturePort.Country.Name,
                   ArrivalPortId = v.ArrivalPortId,
                   ArrivalPortName = v.ArrivalPort.Name,
                   ArrivalCountryName = v.ArrivalPort.Country.Name,
                   StartTimestamp = v.StartTimestamp,
                   EndTimestamp = v.EndTimestamp
               })
               .ToListAsync();
        }

        public async Task<Voyage> GetByIdAsync(int id)
        {
            return await _context.Voyages.FindAsync(id);
        }
    }
}
