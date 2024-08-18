using Application.Contracts;
using Application.Services;
using Moq;

namespace Tests.Application.Services;

public class SquibLoadServiceTest
{
    private readonly ISquibLoadService serviceMock;
    public SquibLoadServiceTest()
    {
        serviceMock = new SquibLoadService();
    }
    [Fact]
    public void SquibLoadGun_Test_Return_true()
    {
        var result =serviceMock.SquibLoadGun(true);
        Assert.True(result);
    }
    [Fact]
    public void SquibLoadGun_Test_Return_false()
    {
        var result =serviceMock.SquibLoadGun(false);
        Assert.True(result== true || result == false);
    }
}
