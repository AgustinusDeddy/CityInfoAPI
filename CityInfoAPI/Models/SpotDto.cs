namespace CityInfoAPI.Models
{
    public class SpotDto : LinkedResourceBaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string PreviewImage { get; set; }
    }
}
