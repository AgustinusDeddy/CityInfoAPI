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
        private readonly IUrlHelper _urlHelper;

        public SpotController(ICityInfoRepository cityInfoRepository, ILogger<SpotController> logger, IUrlHelper urlHelper)
        {
            _cityInfoRepository = cityInfoRepository;
            _logger = logger;
            _urlHelper = urlHelper;
        }

        [HttpGet(Name = "GetSpotsForCity")]
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

                spots = spots.Select(spot =>
                {
                    spot = CreateLinksForSpot(spot);
                    return spot;
                });

                var wrapper = new LinkedCollectionResourceWrapperDto<SpotDto>(spots);

                return Ok(CreateLinksForSpots(wrapper));
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

            return Ok(CreateLinksForSpot(spot));
        }

        private SpotDto CreateLinksForSpot(SpotDto spot)
        {
            spot.Links.Add(new LinkDto(_urlHelper.Link("GetSpot",
                    new { id = spot.Id }),
                "self",
                "GET"));

            return spot;
        }

        private LinkedCollectionResourceWrapperDto<SpotDto> CreateLinksForSpots(
            LinkedCollectionResourceWrapperDto<SpotDto> spotsWrapper)
        {
            //link to self
            spotsWrapper.Links.Add(
                new LinkDto(_urlHelper.Link("GetSpotsForCity", new { }),
                    "self",
                    "GET"));

            return spotsWrapper;
        }
    }
}
