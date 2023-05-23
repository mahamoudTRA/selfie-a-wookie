using Moq;
using System.Collections.Generic;
using SelfieAWookie.Core.Domain.Models;
using SelfieAWookie.API.UI.Controllers;
using SelfieAWookie.Core.Domain.Repositories;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.API.UI.Dtos;

namespace SelfieAWookie.Tests.Selfie;

public class SelfieControllerTests
{
    private readonly Mock<ISelfieRepository> _selfieRepositoryMock;
    private readonly SelfieController _selfieController;

    public SelfieControllerTests()
    {
        _selfieRepositoryMock = new Mock<ISelfieRepository>();
        _selfieController = new SelfieController(_selfieRepositoryMock.Object);
    }


    [Fact]
    public async void Should_Returns_List_Of_Selfie()
    {
        //Arrange
        

        ICollection<SelfieAWookie.Core.Domain.Models.Selfie> selfies = new Collection<Core.Domain.Models.Selfie>()
        {
            new SelfieAWookie.Core.Domain.Models.Selfie()
            {
                Id = 1,
                Title = "Selfie 1",
                ImagePath = "Pas d'image",
                WookieId = 1,
                Wookie = new Wookie()
                {
                    Id = 1,
                    Name = "Wookie 1"
                }
            },
            new SelfieAWookie.Core.Domain.Models.Selfie()
            {
                Id = 2,
                Title = "Selfie 2",
                ImagePath = "Image",
                WookieId = 2,
                Wookie = new Wookie()
                {
                    Id = 2,
                    Name = "Wookie 2"
                }
            },
        };


        _selfieRepositoryMock.Setup(item => item.GetAll(It.IsAny<int>())).ReturnsAsync(selfies);

        var selfieController = new SelfieController(_selfieRepositoryMock.Object);

        //Act
        var result = await _selfieController.GetAll();


        //Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);

        OkObjectResult? okResult = result as OkObjectResult;
        Assert.NotNull(okResult?.Value);
        Assert.IsType<List<SelfieResumeDTO>>(okResult?.Value);

        List<SelfieResumeDTO>? selfieResumeDTOs = okResult?.Value as List<SelfieResumeDTO>;

        Assert.True(selfieResumeDTOs?.Count == selfies.Count);
        
    }

    [Fact]
    public async void Should_Add_One_Selfie()
    {
        // Arrange
        SelfieDTO selfieDto = new SelfieDTO() { ImagePath = "Image", Title = "New selfie", WookieId = 1};
        Core.Domain.Models.Selfie selfie = new Core.Domain.Models.Selfie()
        {
            ImagePath = selfieDto.ImagePath,
            Title = selfieDto.Title,
            WookieId = selfieDto.WookieId
        };
        SelfieController selfieController = new SelfieController(_selfieRepositoryMock.Object);
        _selfieRepositoryMock.Setup(item => item.AddOneSelfie(It.IsAny<Core.Domain.Models.Selfie>())).ReturnsAsync(new Core.Domain.Models.Selfie() { Id = 4});
      
        // Act

        var result = await _selfieController.AddOneSelfie(selfieDto);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);

        var addedSelfie = (result as OkObjectResult)?.Value as SelfieDTO;
        Assert.IsType<SelfieDTO>(addedSelfie);
        Assert.NotNull(addedSelfie);
        Assert.True(addedSelfie.Id > 0);
    }
}
