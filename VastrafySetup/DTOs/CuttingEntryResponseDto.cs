namespace VastrafySetup.DTOs
{
    public class CuttingEntryResponseDto
    {
        public Guid Id { get; set; }
        public string StyleName { get; set; }
        public string Brand { get; set; }
        public DateTime EntryDate { get; set; }
        public List<SizeQuantityDto> SizeQuantities { get; set; }
    }

    public class SizeQuantityDto
    {
        public string Size { get; set; }
        public int Quantity { get; set; }
    }
}
