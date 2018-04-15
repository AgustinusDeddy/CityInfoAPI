using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CityInfoAPI.Core.Repository;
using CityInfoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CityInfoAPI.Controllers
{
    [Route("api/cities/{cityId}/spots")]
    public class SpotController : Controller
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly ILogger<SpotController> _logger;

        public SpotController(ICityInfoRepository cityInfoRepository, ILogger<SpotController> logger)
        {
            _cityInfoRepository = cityInfoRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetSpotsInCity(int cityId)
        {
            try
            {
                _logger.LogTrace($"Getting list of spotfs for city id : {cityId}");

                var spotsFromRepo = _cityInfoRepository.GetSpotsForCity(cityId);

                if (!spotsFromRepo.Any())
                {
                    _logger.LogInformation($"City Id {cityId} is not exist");
                    return NotFound();
                }
                   
                var spots = Mapper.Map<IEnumerable<SpotDto>>(spotsFromRepo);

                return Ok(spots);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on getting sports for city : {cityId}");
                _logger.LogError(e.ToString());
                throw;
            }
            
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
