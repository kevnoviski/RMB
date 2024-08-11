using Microsoft.AspNetCore.Mvc;

namespace Application.Contracts;

public interface IGunService
{
    Task<IActionResult> GetCurrentClip();
    Task<IActionResult> Fire(int bullets);
    Task<IActionResult> Reload(int bullets);
    Task<IActionResult> Unsquib();
    Task<IActionResult> Burst(int burst);
}