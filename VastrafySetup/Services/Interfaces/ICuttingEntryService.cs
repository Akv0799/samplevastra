using VastrafySetup.DTOs;

namespace VastrafySetup.Services.Interfaces
{
    public interface ICuttingEntryService
    {
        Task<List<CuttingEntryDto>> GetAllCuttingEntriesAsync();
        Task AddCuttingEntryAsync(CuttingEntryDto dto);
    }
}
