using VastrafySetup.Data;
using VastrafySetup.Interfaces;
using VastrafySetup.DTOs;
using VastrafySetup.Models;
using Microsoft.EntityFrameworkCore;
using VastrafySetup.Models.Entities;
using VastrafySetup.Services;
using VastrafySetup.Repositories.Interfaces;
using VastrafySetup.Services.Interfaces;

namespace VastrafySetup.Services
{
    public class CuttingEntryService : ICuttingEntryService
    {
        private readonly ICuttingEntryRepository _repository;

        public CuttingEntryService(ICuttingEntryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CuttingEntryDto>> GetAllCuttingEntriesAsync()
        {
            var cuttingEntries = await _repository.GetAllAsync();

            return cuttingEntries.Select(e => new CuttingEntryDto
            {
                StyleName = e.StyleName,
                BrandName = e.BrandName,
                CuttingDate = e.CuttingDate,
                Sizes = e.SizeQuantities.Select(sq => new SizeDto
                {
                    Size = sq.Size,
                    Quantity = sq.Quantity
                }).ToList()
            }).ToList();
        }

        public async Task AddCuttingEntryAsync(CuttingEntryDto dto)
        {
            var cuttingEntry = new CuttingEntry
            {
                Id = Guid.NewGuid(),
                StyleName = dto.StyleName,
                BrandName = dto.BrandName,
                CuttingDate = dto.CuttingDate,
                SizeQuantities = dto.Sizes.Select(s => new SizeQuantity
                {
                    Size = s.Size,
                    Quantity = s.Quantity
                }).ToList()
            };

            await _repository.AddAsync(cuttingEntry);
        }
    }
}


//private readonly AppDbContext _context;

//public CuttingEntryService(AppDbContext context)
//{
//    _context = context;
//}

//public async Task AddCuttingEntryAsync(CuttingEntryDto dto)
//{
//    var cuttingEntry = new CuttingEntry
//    {
//        EntryDate = dto.EntryDate,
//        CuttingDetails = dto.Details.Select(d => new CuttingEntryDetail
//        {
//            StyleId = d.StyleId,
//            SizeId = d.SizeId,
//            Quantity = d.Quantity
//        }).ToList()
//    };

//    await _context.CuttingEntries.AddAsync(cuttingEntry);
//    await _context.SaveChangesAsync();
//}

//public async Task<IEnumerable<CuttingEntryResponseDto>> GetAllCuttingEntriesAsync()
//{
//    var entries = await _context.CuttingEntries
//        .Include(e => e.SizeQuantities)
//        .ToListAsync();

//    return entries.Select(e => new CuttingEntryResponseDto
//    {
//        Id = e.Id,
//        StyleName = e.StyleName,
//        Brand = e.Brand,
//        EntryDate = e.EntryDate,
//        SizeQuantities = e.SizeQuantities
//            .Select(sq => new SizeQuantityDto
//            {
//                Size = sq.Size,
//                Quantity = sq.Quantity
//            }).ToList()
//    });
//}