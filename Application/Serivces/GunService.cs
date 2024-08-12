using Application.Contracts;
using Application.Responses;

namespace Application.Services;

public class GunService : IGunService
{
    private static int magazineSize=30;
    private static int clip = 30;
    private static bool squibloaded=false;
    public async Task<FireResponse> Fire()
    {
        FireResponse response;

        if (clip==0 || SquibLoad())
        {
            response=new FireResponse(
                statusCode: 400,
                remainingBullets: clip,
                squibLoadOccurred: squibloaded,
                message: clip==0 ? "Clip is empty." : "Squib load detected."
            );
        } 
        else 
        {
            clip -=1;
            response=new FireResponse(
                statusCode: 200,
                remainingBullets: clip,
                squibLoadOccurred: squibloaded,
                message:  "Bullet fired successfully."
            );
        }
        return await Task.FromResult(response);
    }

    public async Task<ClipStatusResponse> GetCurrentClip()
    {
        return await Task.FromResult(new ClipStatusResponse(200,clip));
    }

    public async Task<ReloadResponse> Reload(int bullets)
    {
        ReloadResponse response;
        if(( clip + bullets) > magazineSize) 
        {
            response= new ReloadResponse(
                statusCode: 400,
                currentClip: clip,
                message:  "Reload amount exceeds magazine size."
            );
        }
        else
        {
            clip+=bullets;
            response= new ReloadResponse(
                statusCode: 200,
                currentClip: clip,
                message:  "Gun reloaded successfully."
            );
        }
        return await Task.FromResult(response);
    }
    private bool SquibLoad()
    {
        if (!squibloaded)
        {
            Random rnd = new Random();
            squibloaded = rnd.Next(1, 100) % 2 == 0;
            return squibloaded;
        }
        return true;
    }
    public async Task<UnsquibResponse> Unsquib()
    {
        UnsquibResponse response;
        if (squibloaded)
        {
            squibloaded = false;
            response = new UnsquibResponse(
                statusCode:200,
                squibloaded:squibloaded,
                message:"Squib load fixed, gun is operational."
            );
        }
        else
        {
            response = new UnsquibResponse(
                statusCode:400,
                squibloaded:squibloaded,
                message:"Gun is not in a squib load state."
            );
        }
        return await Task.FromResult(response);
    }

    public async Task<MagazineSizeResponse> SetMagazineSize(int size)
    {
        magazineSize = size;
        return await Task.FromResult(new MagazineSizeResponse(200,magazineSize));
    }
}