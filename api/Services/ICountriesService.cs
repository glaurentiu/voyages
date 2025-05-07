using NapaTraineeAPI.Models;

namespace NapaTraineeAPI.Services
{
    public interface ICountriesService
    {
        Task<IEnumerable<Country>> GetAllAsync();
        Task<Country> GetByIdAsync(int id);
    }
}
