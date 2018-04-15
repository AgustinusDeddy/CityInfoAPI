using System.Collections.Generic;

namespace CityInfoAPI.Models
{
    public class LinkedResourceBaseDto
    {
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}
