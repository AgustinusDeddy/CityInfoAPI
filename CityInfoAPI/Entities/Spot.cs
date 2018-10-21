using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfoAPI.Entities
{
    public class Spot
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(500)]
        public string Explanation { get; set; }

        public int SpotTypeId { get; set; }
        [ForeignKey("SpotTypeId")]
        public SpotType Type { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        public int CityId { get; set; }

        public string PreviewImage { get; set; }
    }
}
