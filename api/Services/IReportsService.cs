namespace NapaTraineeAPI.Services
{
    public interface IReportsService
    {
        Task<Dictionary<string, int>> GetVisitedCountriesLastYearAsync();
    }
}
