namespace VastrafySetup.DTOs
{
    public class CuttingEntryDto
    {
        public string StyleName { get; set; }
        public string BrandName { get; set; }
        public DateTime CuttingDate { get; set; }
        public List<SizeDto> Sizes { get; set; }
    }

    public class SizeDto
    {
        public string Size { get; set; }
        public int Quantity { get; set; }
    }
}
