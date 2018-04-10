using System.Collections.Generic;
using CityInfoAPI.Entities;

namespace CityInfoAPI.Core.Repository
{
    public interface ICityInfoRepository
    {
        IEnumerable<City> GetCities();
    }
}
