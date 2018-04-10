using System.Collections.Generic;
using System.Linq;
using CityInfoAPI.Core.Repository;
using CityInfoAPI.Entities;

namespace CityInfoAPI.Repository
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _cityInfoContext;

        public CityInfoRepository(CityInfoContext cityInfoContext)
        {
            _cityInfoContext = cityInfoContext;
        }
        public IEnumerable<City> GetCities()
        {
            var cityEntities = _cityInfoContext.Cities.OrderBy(c => c.Name);
            return cityEntities;
        }
    }
}
