using Microsoft.AspNetCore.Mvc;

namespace Application.Contracts;

public interface IGunService
{
    Task<int> GetCurrentClip();
    Task<int> Fire(int bullets);
    Task<int> Reload(int bullets);
    Task<bool> Unsquib();
    Task<int> SetMagazineSize(int size);
}