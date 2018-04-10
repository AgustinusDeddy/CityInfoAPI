using System.Collections.Generic;
using CityInfoAPI.Entities;

namespace CityInfoAPI.Core.Repository
{
    public interface ICityInfoRepository
    {
        IEnumerable<City> GetCities();
        City GetCity(int id);
        IEnumerable<Spot> GetSpotsForCity(int cityId);
    }
}
