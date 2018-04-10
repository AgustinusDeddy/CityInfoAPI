using System.Collections.Generic;
using AutoMapper;
using CityInfoAPI.Core.Repository;
using CityInfoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoAPI.Controllers
{
    [Route("api/cities/{cityId}/spots")]
    public class SpotController : Controller
    {
        private readonly ICityInfoRepository _cityInfoRepository;

        public SpotController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        public IActionResult GetSpotsInCity(int cityId)
        {
            var spotsFromRepo = _cityInfoRepository.GetSpotsForCity(cityId);

            var spots = Mapper.Map<IEnumerable<SpotDto>>(spotsFromRepo);

            return Ok(spots);
        }
    }
}
