namespace VastrafySetup.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Style> Style { get; set; }
    }
}
