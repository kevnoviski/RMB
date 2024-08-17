
using Api.Controllers;
using Application.Contracts;
using Application.Responses;
using Moq;

namespace Tests.Api.Controllers
{
    public class OldGunControllerTest
    {
        private readonly Mock<IGunService> gunServiceMock;
        private readonly OldGunController oldGunController;
        private ClipStatusResponse clipStatusResponse;
        private FireResponse fireResponse;
        private ReloadResponse reloadResponse;
        private UnsquibResponse unsquibResponse;
        private MagazineSizeResponse magazineSizeResponse;
        
        public OldGunControllerTest()
        {
            gunServiceMock = new Mock<IGunService>();

            clipStatusResponse = new ClipStatusResponse(200,30);
            fireResponse = new FireResponse(200,29,false);
            reloadResponse = new ReloadResponse(200,30,"sucess");
            unsquibResponse = new UnsquibResponse(200,false);
            magazineSizeResponse = new MagazineSizeResponse(200,40);

            gunServiceMock.Setup(s => s.GetCurrentClip()).Returns(Task.FromResult(clipStatusResponse));

            gunServiceMock.Setup(s => s.Fire()).Returns(Task.FromResult(fireResponse));

            gunServiceMock.Setup(s => s.Reload(It.IsAny<int>())).Returns(Task.FromResult(reloadResponse));

            gunServiceMock.Setup(s => s.Unsquib()).Returns(Task.FromResult(unsquibResponse));

            gunServiceMock.Setup(s => s.SetMagazineSize(It.IsAny<int>())).Returns(Task.FromResult(magazineSizeResponse));

            oldGunController = new OldGunController(gunServiceMock.Object);
        }

        [Fact]
        public async Task GetCurrentClip_Test()
        {
            var Response=await oldGunController.GetCurrentClip();
            Assert.True(((Microsoft.AspNetCore.Mvc.ObjectResult)Response).StatusCode == 200);
        }

        [Fact]
        public async Task Fire_Test_Return_OK()
        {
            var Response=await oldGunController.Fire();
            Assert.True(((Microsoft.AspNetCore.Mvc.ObjectResult)Response).StatusCode == 200);
        }
        [Fact]
        public async Task Fire_Test_Return_BadRequest()
        {
            fireResponse = new FireResponse(400,29,true);
            gunServiceMock.Setup(s => s.Fire()).Returns(Task.FromResult(fireResponse));

            var Response=await oldGunController.Fire();
            Assert.True(((Microsoft.AspNetCore.Mvc.ObjectResult)Response).StatusCode == 400);
        }

        [Fact]
        public async Task Reload_Test_Return_OK()
        {
            var Response=await oldGunController.Reload(10);
            Assert.True(((Microsoft.AspNetCore.Mvc.ObjectResult)Response).StatusCode == 200);
        }
        [Fact]
        public async Task Reload_Test_Return_BadRequest()
        {
            reloadResponse = new ReloadResponse(400,30);
            gunServiceMock.Setup(s => s.Reload(It.IsAny<int>())).Returns(Task.FromResult(reloadResponse));

            var Response=await oldGunController.Reload(10);
            Assert.True(((Microsoft.AspNetCore.Mvc.ObjectResult)Response).StatusCode == 400);
        }
        [Fact]
        public async Task Unsquib_Test_Return_OK()
        {
            var Response=await oldGunController.Unsquib();
            Assert.True(((Microsoft.AspNetCore.Mvc.ObjectResult)Response).StatusCode == 200);
        }

        [Fact]
        public async Task Unsquib_Test_Return_BadRequest()
        {
            unsquibResponse = new UnsquibResponse(400,false);
            gunServiceMock.Setup(s => s.Unsquib()).Returns(Task.FromResult(unsquibResponse));

            var Response=await oldGunController.Unsquib();
            Assert.True(((Microsoft.AspNetCore.Mvc.ObjectResult)Response).StatusCode == 400);
        }

        [Fact]
        public async Task SetMagazineSize_Test_Return_OK()
        {
            var Response=await oldGunController.SetMagazineSize(40);
            Assert.True(((Microsoft.AspNetCore.Mvc.ObjectResult)Response).StatusCode == 200);
        }

        [Fact]
        public async Task SetMagazineSize_Test_Return_BadRequest()
        {
            magazineSizeResponse = new MagazineSizeResponse(400,40);
            gunServiceMock.Setup(s => s.SetMagazineSize(It.IsAny<int>())).Returns(Task.FromResult(magazineSizeResponse));

            var Response=await oldGunController.SetMagazineSize(40);
            Assert.True(((Microsoft.AspNetCore.Mvc.ObjectResult)Response).StatusCode == 400);
        }
    }
}