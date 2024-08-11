using Application.Contracts;
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

    [HttpGet("clip")]
    [ProducesResponseType(typeof(int),200)]
    public async Task<IActionResult> GetCurrentClip()
    {      
        return Ok(await _gunservice.GetCurrentClip());
    }  

    [HttpPost("fire")]
    [ProducesResponseType(typeof(int),201)]
    [ProducesResponseType(typeof(string),400)]
    public async Task<IActionResult> Fire(int bullets)
    {
        int result = await _gunservice.Fire(bullets);
        if( result > 0)
        {
            return Ok(result);
        }
        else if (result == 0)
        {
            return BadRequest("Squib Load!");
        }
        return BadRequest("Reload!");
    }

    [HttpPut("reload")]
    [ProducesResponseType(typeof(int),200)]
    public async Task<IActionResult> Reload(int bullets)
    {
        return Ok(await _gunservice.Reload(bullets));
    }

    [HttpPut("Unsquib")]
    [ProducesResponseType(typeof(bool),204)]
    public async Task<IActionResult> Unsquib()
    {
        return Ok(await _gunservice.Unsquib());
    }

    [HttpPost("magazineSize")]
    public async Task<IActionResult> SetMagazineSize(int size)
    {
        return Ok(await _gunservice.SetMagazineSize(size));
    }
}
