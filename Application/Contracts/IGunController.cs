using Microsoft.AspNetCore.Mvc;

namespace Application.Contracts;

public interface IGunController
{
    Task<IActionResult> GetCurrentClip();
    Task<IActionResult> Fire();
    Task<IActionResult> Reload(int bullets);
    Task<IActionResult> Unsquib();
    Task<IActionResult> SetMagazineSize(int size);
}