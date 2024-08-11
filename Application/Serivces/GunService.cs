using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services;

public class GunService : IGunService
{
    public Task<IActionResult> Burst(int burst)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Fire(int bullets)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> GetCurrentClip()
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Reload(int bullets)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Unsquib()
    {
        throw new NotImplementedException();
    }
}