using NapaTraineeAPI.Models;

namespace NapaTraineeAPI.Services
{
    public interface IShipsService
    {
        Task<IEnumerable<Ship>> GetAllAsync();
        Task<Ship> GetByIdAsync(int id);
    }
}
