using Microsoft.AspNetCore.Mvc;

namespace Application.Contracts;

public interface IGunController
{
    Task<IActionResult> GetCurrentClip();
    Task<IActionResult> Fire(int bullets);
    Task<IActionResult> Reload(int bullets);
    Task<IActionResult> Unsquib();
}