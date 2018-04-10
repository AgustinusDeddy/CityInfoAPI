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

        [HttpGet(Name = "GetCities")]
        public IActionResult GetCities()
        {
            var citiesFromRepo = _cityInfoRepository.GetCities();

            var cities = Mapper.Map<IEnumerable<CityDto>>(citiesFromRepo);

            return Ok(cities);
        }
    }
}
