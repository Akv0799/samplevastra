using Microsoft.EntityFrameworkCore;
using VastrafySetup.Data;
using VastrafySetup.Models.Entities;
using VastrafySetup.Repositories.Interfaces;

namespace VastrafySetup.Repositories
{
    public class CuttingEntryRepository : ICuttingEntryRepository
    {
        private readonly AppDbContext _context;

        public CuttingEntryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CuttingEntry>> GetAllAsync()
        {
            return await _context.CuttingEntries
                //.Include(e => e.CuttingDetails)
                .Include(e => e.SizeQuantities)
                .ToListAsync();
        }

        public async Task AddAsync(CuttingEntry entry)
        {
            await _context.CuttingEntries.AddAsync(entry);
            await _context.SaveChangesAsync();
        }
    }
}
