using System.Collections.Generic;
using System.Linq;
using CityInfoAPI.Core.Repository;
using CityInfoAPI.Entities;
using Microsoft.EntityFrameworkCore;

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

        public City GetCity(int id)
        {
            return _cityInfoContext.Cities.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Spot> GetSpotsForCity(int cityId)
        {
            var spots = _cityInfoContext.Spots.Where(s => s.CityId == cityId).Include(t => t.Type).OrderBy(p => p.Name).ToList();
            return spots;
        }
    }
}
