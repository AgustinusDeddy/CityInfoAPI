using System.Collections.Generic;
using CityInfoAPI.Entities;

namespace CityInfoAPI.Core.Repository
{
    public interface ICityInfoRepository
    {
        bool IsCityExist(int id);
        IEnumerable<City> GetCities();
        City GetCity(int id);
        IEnumerable<Spot> GetSpotsForCity(int cityId);
        Spot GetSpotForCity(int cityId, int id);
        
    }
}
