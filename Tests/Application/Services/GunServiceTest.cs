using Application.Contracts;
using Application.Responses;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Moq;

namespace Tests.Application.Services;

public class GunServiceTest
{
    private readonly GunService gunService;
    private readonly Mock<IGunRepository> _gunRepository ;
    private readonly Mock<ISquibLoadService> _squibLoadService;

    private Gun gunmock;
    public GunServiceTest()
    {
        _gunRepository=  new Mock<IGunRepository>();
        _squibLoadService = new Mock<ISquibLoadService>();
        gunService = new GunService(_gunRepository.Object,_squibLoadService.Object);

        gunmock = new Gun();
    }

    [Fact]
    public async Task Fire_Test_Return_OK()
    {
        gunmock = new Gun()
        {
            Id=1,
            Clip = 30,
            MagazineSize=30,
            ModelName="XX",
            SquibLoaded=false
        };
        _gunRepository.Setup(s=> s.GetGunAsync()).Returns(Task.FromResult(gunmock));
        _squibLoadService.Setup(s => s.SquibLoadGun(It.IsAny<bool>())).Returns(false);
        _gunRepository.Setup(s => s.UpdateGunAsync(It.IsAny<Gun>())).Returns(Task.FromResult(gunmock));
        FireResponse response =await gunService.Fire();
        Assert.True(response.StatusCode==200);
    }
    [Fact]
    public async Task Fire_Test_Return_400_Reload()
    {
        gunmock = new Gun()
        {
            Id=1,
            Clip = 0,
            MagazineSize=30,
            ModelName="XX",
            SquibLoaded=false
        };
        _gunRepository.Setup(s=> s.GetGunAsync()).Returns(Task.FromResult(gunmock));
        _squibLoadService.Setup(s => s.SquibLoadGun(It.IsAny<bool>())).Returns(false);
        FireResponse response =await gunService.Fire();
        Assert.True(response.StatusCode==400);
    }
    [Fact]
    public async Task Fire_Test_Return_400_SquibLoaded()
    {
        gunmock = new Gun()
        {
            Id=1,
            Clip =29,
            MagazineSize=30,
            ModelName="XX",
            SquibLoaded=false
        };
        _gunRepository.Setup(s=> s.GetGunAsync()).Returns(Task.FromResult(gunmock));
        _squibLoadService.Setup(s => s.SquibLoadGun(It.IsAny<bool>())).Returns(true);
        FireResponse response =await gunService.Fire();
        Assert.True(response.StatusCode==400);
    }
    [Fact]
    public async Task GetCurrentClip_Test()
    {
        gunmock = new Gun()
        {
            Id=1,
            Clip =29,
            MagazineSize=30,
            ModelName="XX",
            SquibLoaded=false
        };
        _gunRepository.Setup(s=> s.GetGunAsync()).Returns(Task.FromResult(gunmock));
        ClipStatusResponse  response =await gunService.GetCurrentClip();
        Assert.True(response.StatusCode==200);
    }

    [Fact]
    public async Task Reload_Test_Return_OK()
    {
        gunmock = new Gun()
        {
            Id=1,
            Clip =29,
            MagazineSize=30,
            ModelName="XX",
            SquibLoaded=false
        };
        _gunRepository.Setup(s=> s.GetGunAsync()).Returns(Task.FromResult(gunmock));
        _gunRepository.Setup(s=> s.UpdateGunAsync(It.IsAny<Gun>())).Returns(Task.FromResult(gunmock));
        ReloadResponse response = await gunService.Reload(1);
        Assert.True(response.StatusCode==200);
    }
    [Fact]
    public async Task Reload_Test_Return_BadRequest()
    {
        gunmock = new Gun()
        {
            Id=1,
            Clip =30,
            MagazineSize=30,
            ModelName="XX",
            SquibLoaded=false
        };
        _gunRepository.Setup(s=> s.GetGunAsync()).Returns(Task.FromResult(gunmock));
        _gunRepository.Setup(s=> s.UpdateGunAsync(It.IsAny<Gun>())).Returns(Task.FromResult(gunmock));
        ReloadResponse response = await gunService.Reload(1);
        Assert.True(response.StatusCode==400);
    }

    [Fact]
    public async Task Unsquib_Test_OK()
    {
        gunmock = new Gun()
        {
            Id=1,
            Clip =30,
            MagazineSize=30,
            ModelName="XX",
            SquibLoaded=true
        };
        _gunRepository.Setup(s=> s.GetGunAsync()).Returns(Task.FromResult(gunmock));
        _gunRepository.Setup(s=> s.UpdateGunAsync(It.IsAny<Gun>())).Returns(Task.FromResult(gunmock));
        UnsquibResponse response = await gunService.Unsquib();
        Assert.True(response.StatusCode==200);

    }
    [Fact]
    public async Task Unsquib_Test_BadRequest()
    {
        gunmock = new Gun()
        {
            Id=1,
            Clip =30,
            MagazineSize=30,
            ModelName="XX",
            SquibLoaded=false
        };
        _gunRepository.Setup(s=> s.GetGunAsync()).Returns(Task.FromResult(gunmock));
        UnsquibResponse response = await gunService.Unsquib();
        Assert.True(response.StatusCode==400);
    }
    [Fact]
    public async Task SetMagazineSize_Test()
    {
        gunmock = new Gun()
        {
            Id=1,
            Clip =30,
            MagazineSize=30,
            ModelName="XX",
            SquibLoaded=false
        };
        _gunRepository.Setup(s=> s.GetGunAsync()).Returns(Task.FromResult(gunmock));
        _gunRepository.Setup(s=> s.UpdateGunAsync(It.IsAny<Gun>())).Returns(Task.FromResult(gunmock));
        MagazineSizeResponse response = await gunService.SetMagazineSize(100);
        Assert.Equal( 100,response.MagazineSize);
    }
}
