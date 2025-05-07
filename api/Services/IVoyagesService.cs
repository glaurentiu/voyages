using NapaTraineeAPI.Models;


namespace NapaTraineeAPI.Services
{
    public interface IVoyagesService
    {
        Task<IEnumerable<VoyageDto>> GetAllAsync();
        Task<Voyage> GetByIdAsync(int id);
    }
}
