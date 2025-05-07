using NapaTraineeAPI.Models;

namespace NapaTraineeAPI.Services
{
    public interface IPortsService
    {
        Task<IEnumerable<Port>> GetAllAsync();
        Task<Port> GetByIdAsync(int id);
    }
}
