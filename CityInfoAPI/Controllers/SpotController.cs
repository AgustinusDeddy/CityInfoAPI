using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public IActionResult GetSpotsInCity(int cityId)
        {
            var spotsFromRepo = _cityInfoRepository.GetSpotsForCity(cityId);

            if(!spotsFromRepo.Any())
                return NotFound();

            var spots = Mapper.Map<IEnumerable<SpotDto>>(spotsFromRepo);

            return Ok(spots);
        }

        [HttpGet("{id}", Name = "GetSpot")]
        public IActionResult GetSpotForCity(int cityId, int id)
        {
            var spotFromRepo = _cityInfoRepository.GetSpotForCity(cityId, id);

            if(spotFromRepo == null)
                return NotFound();

            var spot = Mapper.Map<SpotDto>(spotFromRepo);

            return Ok(spot);
        }
    }
}
