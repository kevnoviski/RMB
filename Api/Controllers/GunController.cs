using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Route("[controller]")]
public class GunController : ControllerBase, IGunController
{
    private IGunService _gunservice;
    private static int clip = 30;
    private static bool squibloaded=false;
    private static int burstNumber=1;
    
    [HttpGet("clip")]
    [ProducesResponseType(typeof(int),200)]
    public async Task<IActionResult> GetCurrentClip()
    {
        var result=  await Task.FromResult(clip);

        return Ok(result);
    }  

    [HttpPost("fire")]
    [ProducesResponseType(typeof(int),201)]
    [ProducesResponseType(typeof(string),400)]
    public async Task<IActionResult> Fire(int bullets)
    {
        if (clip > 0 && bullets < clip)
        {
            clip = clip - bullets;
            return Ok(await Task.FromResult(clip));
        }
        else if (clip > 0 && bullets > clip)
        {
            var bulletsFired = clip;
            clip=0;
            return Ok(await Task.FromResult(bulletsFired));
        }
        else
        {
            return BadRequest("Reload!");
        }
    }

    [HttpPut("reload")]
    [ProducesResponseType(typeof(int),200)]
    public async Task<IActionResult> Reload(int bullets)
    {
        clip=clip + bullets;
        
        if(!isSquib()) 
        {
            return Ok(await Task.FromResult(clip));
        }
        squibloaded=true;
        return BadRequest("Squib Load");
    }

    private bool isSquib()
    {
        if (squibloaded) return true;
        
        return SquibLoad();
    }

    [HttpPut("Unsquib")]
    [ProducesResponseType(typeof(bool),204)]
    public async Task<IActionResult> Unsquib()
    {
        squibloaded=false;
        return Ok(await Task.FromResult(!squibloaded));
    }

    private bool SquibLoad()
    {
        Random rnd = new Random();
        return rnd.Next(1, 10) % 2 == 0;
    }

    [HttpPut("burst")]
    [ProducesResponseType(typeof(int),204)]
    public async Task<IActionResult> Burst(int burst)
    {
        burstNumber = burst;
        return Ok(await  Task.FromResult(burstNumber));
    }
}
