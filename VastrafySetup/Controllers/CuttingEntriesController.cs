using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VastrafySetup.DTOs;
using VastrafySetup.Interfaces;
using VastrafySetup.Services.Interfaces;

namespace VastrafySetup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuttingEntriesController : ControllerBase
    {
        private readonly ICuttingEntryService _service;

        public CuttingEntriesController(ICuttingEntryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddCuttingEntry([FromBody] CuttingEntryDto dto)
        {
            await _service.AddCuttingEntryAsync(dto);
            return Ok("Cutting Entry Saved Successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCuttingEntries()
        {
            var entries = await _service.GetAllCuttingEntriesAsync();
            return Ok(entries);
        }

    }
}
