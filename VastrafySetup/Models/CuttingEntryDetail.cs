using VastrafySetup.Models.Entities;

namespace VastrafySetup.Models
{
    public class CuttingEntryDetail
    {
        public int Id { get; set; }

        public int CuttingEntryId { get; set; }
        public CuttingEntry CuttingEntry { get; set; }

        public int StyleId { get; set; }
        public Style Style { get; set; }

        public int SizeId { get; set; }
        public Size Size { get; set; }

        public int Quantity { get; set; }
    }
}
