using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Application.Contracts;

public interface IGunService
{
    Task<ClipStatusResponse> GetCurrentClip();
    Task<FireResponse> Fire();
    Task<ReloadResponse> Reload(int bullets);
    Task<UnsquibResponse> Unsquib();
    Task<MagazineSizeResponse> SetMagazineSize(int size);
}