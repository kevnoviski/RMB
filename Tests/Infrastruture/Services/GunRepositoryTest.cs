using Domain.Entities;
using Domain.Interfaces;
using Infrastruture.Services;
using Moq;

namespace Tests.Infrastruture.Services;

public class GunRepositoryTest
{
    private readonly IGunRepository gunRepository;
    private readonly Mock<IGunFakeContext> gunFakeContext;
    public GunRepositoryTest()
    {
        gunFakeContext = new Mock<IGunFakeContext>();
        gunRepository = new GunRepository(gunFakeContext.Object);
    }

    [Fact]
    public async Task GetGunAsync_Test()
    {
        var gunmock = new Gun()
        {
            Id=1,
            Clip = 30,
            MagazineSize=30,
            ModelName="XX",
            SquibLoaded=false
        };
        gunFakeContext.Setup(s => s.GetGun()).Returns(gunmock);
        var result = await gunRepository.GetGunAsync();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task UpdateGunAsync_Test()
    {
        var gunmock = new Gun()
        {
            Id=1,
            Clip = 30,
            MagazineSize=30,
            ModelName="XX",
            SquibLoaded=false
        };
        gunFakeContext.Setup(s => s.UpdateDefaultGun(It.IsAny<Gun>())).Returns(gunmock);
        var result = await gunRepository.UpdateGunAsync(gunmock);
        Assert.NotNull(result);
    }
}
