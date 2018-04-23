using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityInfoAPI.Controllers;
using CityInfoAPI.Core.Repository;
using CityInfoAPI.Entities;
using CityInfoAPI.Helpers;
using CityInfoAPI.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CityInfoAPI.Test.Controllers
{
    public class SpotControllerTest
    {
        [Fact]
        public async Task GetSpots_EmptySpots_ReturnNotFound()
        {
            //Arrange
            var cityInfoRepoMock = new Mock<ICityInfoRepository>();
            var loggerMock = new Mock<ILogger<SpotController>>();
            var urlHelperMock = new Mock<IUrlHelper>();

            var param = new SpotResourceParameters()
            {
                cityId = 1,
                SearchQuery = "",
                Type = ""
            };

            cityInfoRepoMock.Setup(c => c.GetSpotsForCity(param)).Returns(() => new List<Spot>());
            
            var controller = new SpotController(cityInfoRepoMock.Object, loggerMock.Object, urlHelperMock.Object);

            //Act
            var result = controller.GetSpotsInCity(param);

            //Assert
            var notFound = result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetSpots_HaveTwoSpots_ReturnOkEmptyList()
        {
            //Arrange

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<City, CityDto>();
                cfg.CreateMap<Spot, SpotDto>()
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Name));
            });

            var cityInfoRepoMock = new Mock<ICityInfoRepository>();
            var loggerMock = new Mock<ILogger<SpotController>>();
            var urlHelperMock = new Mock<IUrlHelper>();

            var param = new SpotResourceParameters()
            {
                cityId = 1,
                SearchQuery = "",
                Type = ""
            };

            cityInfoRepoMock.Setup(c => c.GetSpotsForCity(param)).Returns(() => new List<Spot>()
            {
                new Spot()
                {
                    Id = 1,
                    CityId = 1,
                    Name = "Test Spot 1",
                    Description = "Desc 1"
                },
                new Spot()
                {
                    Id = 2,
                    CityId = 1,
                    Name = "Test Spot 2",
                    Description = "Desc 2"
                }
            });

            var controller = new SpotController(cityInfoRepoMock.Object, loggerMock.Object, urlHelperMock.Object);

            //Act
            var result = controller.GetSpotsInCity(param);

            //Assert
            var okResult = result.Should().BeOfType<OkObjectResult>();
                
            var spots = okResult.Subject.Value.Should().BeAssignableTo<LinkedCollectionResourceWrapperDto<SpotDto>>().Subject;

            spots.Value.Count().Should().Be(2);
        }
    }
}
