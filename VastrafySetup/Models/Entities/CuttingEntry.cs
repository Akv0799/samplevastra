namespace VastrafySetup.Models.Entities
{
    public class CuttingEntry
    {
        public Guid Id { get; set; }
        public string StyleName { get; set; }
        public string BrandName { get; set; }
        public DateTime CuttingDate { get; set; }

        public ICollection<CuttingEntryDetail> CuttingDetails { get; set; }
        public ICollection<SizeQuantity> SizeQuantities { get; set; }
    }

    public class SizeQuantity
    {
        public Guid Id { get; set; }
        public string Size { get; set; }   // Example: "2XL", "4XL"
        public int Quantity { get; set; }

        public Guid CuttingEntryId { get; set; }
        public CuttingEntry CuttingEntry { get; set; }
    }
}
