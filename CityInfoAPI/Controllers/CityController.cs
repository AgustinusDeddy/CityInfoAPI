using System.Collections.Generic;
using AutoMapper;
using CityInfoAPI.Core.Repository;
using CityInfoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoAPI.Controllers
{
    [Route("api/cities")]
    public class CityController : Controller
    {
        private readonly ICityInfoRepository _cityInfoRepository;

        public CityController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        /// <summary>
        /// Retrieve list of cities
        /// </summary>
        /// <returns>Cities</returns>
        [HttpGet(Name = "GetCities")]
        public IActionResult GetCities()
        {
            var citiesFromRepo = _cityInfoRepository.GetCities();

            var cities = Mapper.Map<IEnumerable<CityDto>>(citiesFromRepo);

            return Ok(cities);
        }

        /// <summary>
        /// Returns a city matching provided city id.
        /// </summary>
        /// <remarks>
        /// Here is a sample remarks placeholder.
        /// </remarks>
        /// <param name="cityId">The city id to search for</param>
        /// <returns>A city</returns>
        [HttpGet("{id}", Name = "GetCity")]
        public IActionResult GetCity(int cityId)
        {
            var cityFromRepo = _cityInfoRepository.GetCity(cityId);

            if(cityFromRepo == null)
                return NotFound();

            var city = Mapper.Map<CityDto>(cityFromRepo);

            return Ok(city);
        }
    }
}
