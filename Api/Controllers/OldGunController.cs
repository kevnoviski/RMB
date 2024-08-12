using Application.Contracts;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Route("oldgun")]
public class OldGunController : ControllerBase, IGunController
{
    private readonly IGunService _gunservice;
    public OldGunController(IGunService gunService)
    {
        _gunservice = gunService;
    }

    [HttpGet("currentclip")]
    [ProducesResponseType(typeof(ClipStatusResponse),200)]
    public async Task<IActionResult> GetCurrentClip()
    {      
        var result =await _gunservice.GetCurrentClip();
        return new ObjectResult(result){StatusCode = result.StatusCode};
    }  

    [HttpPost("fire")]
    [ProducesResponseType(typeof(FireResponse),200)]
    [ProducesResponseType(typeof(FireResponse),400)]
    public async Task<IActionResult> Fire()
    {
        var result = await _gunservice.Fire();
        return new ObjectResult(result){StatusCode = result.StatusCode};
    }

    [HttpPut("reload")]
    [ProducesResponseType(typeof(ReloadResponse),200)]
    [ProducesResponseType(typeof(ReloadResponse),400)]
    public async Task<IActionResult> Reload(int bullets)
    {
        var result = await _gunservice.Reload(bullets);
        return new ObjectResult(result){StatusCode = result.StatusCode};
    }

    [HttpPost("unsquib")]
    [ProducesResponseType(typeof(UnsquibResponse),200)]
    [ProducesResponseType(typeof(UnsquibResponse),400)]
    public async Task<IActionResult> Unsquib()
    {
        var result = await _gunservice.Unsquib();
        return new ObjectResult(result){StatusCode = result.StatusCode};
    }

    [HttpPut("magazineSize")]
    [ProducesResponseType(typeof(MagazineSizeResponse),200)]
    [ProducesResponseType(typeof(MagazineSizeResponse),400)]
    public async Task<IActionResult> SetMagazineSize(int size)
    {
        var result = await _gunservice.SetMagazineSize(size);
        return new ObjectResult(result){StatusCode = result.StatusCode};
    }
}
