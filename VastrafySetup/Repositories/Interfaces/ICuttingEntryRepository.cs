using VastrafySetup.Models.Entities;

namespace VastrafySetup.Repositories.Interfaces
{
    public interface ICuttingEntryRepository
    {
        Task<List<CuttingEntry>> GetAllAsync();
        Task AddAsync(CuttingEntry entry);
    }
}
