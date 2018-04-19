using System.Collections.Generic;
using System.Linq;
using CityInfoAPI.Core.Repository;
using CityInfoAPI.Entities;
using CityInfoAPI.Helpers;
using Microsoft.AspNetCore.Cors;
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

        public bool IsCityExist(int id)
        {
            return _cityInfoContext.Cities.Any(c => c.Id == id);
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

        public IEnumerable<Spot> GetSpotsForCity(SpotResourceParameters spotResourceParameters)
        {
            var originalSpots = _cityInfoContext.Spots.Where(s => s.CityId == spotResourceParameters.cityId).AsQueryable();

            if (!string.IsNullOrEmpty(spotResourceParameters.Type))
            {
                var typeClause = spotResourceParameters.Type.Trim().ToLowerInvariant();
                originalSpots =
                    originalSpots.Where(s => s.Type.Name.ToLowerInvariant() == typeClause);
            }

            if (!string.IsNullOrEmpty(spotResourceParameters.SearchQuery))
            {
                var searchQueryForWhereClause = spotResourceParameters.SearchQuery.Trim().ToLowerInvariant();

                originalSpots = originalSpots.Where(
                    a => a.Type.Name.ToLowerInvariant().Contains(searchQueryForWhereClause)
                         || a.Name.ToLowerInvariant().Contains(searchQueryForWhereClause)
                );
            }

            return originalSpots.Include(t => t.Type).OrderBy(p => p.Name).ToList();
        }

        public Spot GetSpotForCity(int cityId, int id)
        {
            return _cityInfoContext.Spots.Where(s => s.CityId == cityId && s.Id == id).Include(t => t.Type).OrderBy(p => p.Name).SingleOrDefault();
        }
    }
}
