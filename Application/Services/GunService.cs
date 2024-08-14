using Application.Contracts;
using Application.Responses;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class GunService : IGunService
{
    private readonly IGunRepository _gunRepository ;
    private readonly ISquibLoadService _squibLoadService;

    public GunService(IGunRepository gunRepository, ISquibLoadService squibLoadService)
    {
        _gunRepository = gunRepository;
        _squibLoadService = squibLoadService;
    }
    public async Task<FireResponse> Fire()
    {
        FireResponse response;

        var currentGun = await _gunRepository.GetGunAsync();

        currentGun.SquibLoaded = _squibLoadService.SquibLoadGun(currentGun.SquibLoaded);

        if (currentGun.SquibLoaded)
        {
            await UpdateGun(currentGun);
            response=RespondSquibloadedDetected(currentGun);
        }
        else if (currentGun.Clip==0 )
        {
            response=RespondClipEmpty(currentGun);
        } 
        else
        {
            var updatedgun = await SubtractClip(currentGun);
            response = RespondBulletFired(updatedgun);
        }
        return response;
    }

    private async Task<Gun> SubtractClip(Gun gun)
    {
        gun.Clip -= 1;
        return await UpdateGun(gun);
    }
    private static FireResponse RespondClipEmpty(Gun gun)
    {
        return new FireResponse(
                statusCode: 400,
                remainingBullets:gun.Clip,
                squibLoadOccurred: gun.SquibLoaded,
                message: "Clip is empty." 
            );
    }
    private static FireResponse RespondSquibloadedDetected(Gun gun )
    {
        return new FireResponse(
                statusCode: 400,
                remainingBullets:gun.Clip,
                squibLoadOccurred: gun.SquibLoaded,
                message: "Squib load detected."
            );
    }
    private static FireResponse RespondBulletFired(Gun gun)
    {
        return new FireResponse(
                statusCode: 200,
                remainingBullets: gun.Clip,
                squibLoadOccurred: gun.SquibLoaded,
                message: "Bullet fired successfully."
            );
    }
    private async Task<Gun> UpdateGun(Gun currentGun)
    {
        return await _gunRepository.UpdateGunAsync(currentGun);
    }

    public async Task<ClipStatusResponse> GetCurrentClip()
    {
        return await Task.FromResult(new ClipStatusResponse(200,(await _gunRepository.GetGunAsync()).Clip));
    }

    public async Task<ReloadResponse> Reload(int bullets)
    {
        ReloadResponse response;
        var currentGun = await _gunRepository.GetGunAsync();
        if(( currentGun.Clip + bullets) > currentGun.MagazineSize) 
        {
            response= new ReloadResponse(
                statusCode: 400,
                currentClip: currentGun.Clip,
                message:  "Reload amount exceeds magazine size."
            );
        }
        else
        {
            currentGun.Clip+=bullets;
            await _gunRepository.UpdateGunAsync(currentGun);
            response= new ReloadResponse(
                statusCode: 200,
                currentClip: currentGun.Clip,
                message:  "Gun reloaded successfully."
            );
        }
        return response;
    }
    public async Task<UnsquibResponse> Unsquib()
    {
        UnsquibResponse response;
        var currentGun = await _gunRepository.GetGunAsync();
        if (currentGun.SquibLoaded)
        {
            currentGun.SquibLoaded = false;
            await UpdateGun(currentGun);
            response = new UnsquibResponse(
                statusCode:200,
                squibloaded:currentGun.SquibLoaded,
                message:"Squib load fixed, gun is operational."
            );
        }
        else
        {
            response = new UnsquibResponse(
                statusCode:400,
                squibloaded:currentGun.SquibLoaded,
                message:"Gun is not in a squib load state."
            );
        }
        return response;
    }

    public async Task<MagazineSizeResponse> SetMagazineSize(int newSize)
    {
        var currentGun = await _gunRepository.GetGunAsync();
        currentGun.MagazineSize = newSize;
        await _gunRepository.UpdateGunAsync(currentGun);
        return new MagazineSizeResponse(200,currentGun.MagazineSize);
    }
}