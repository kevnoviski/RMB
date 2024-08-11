using Application.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services;

public class GunService : IGunService
{
    private static int magazineSize=30;
    private static int clip = 30;
    private static bool squibloaded=false;
    private static int burstNumber=1;
    public async Task<int> Burst(int burst)
    {
        burstNumber = burst;
        return await Task.FromResult(burstNumber == burst ? burstNumber : burst);
    }

    public async Task<int> Fire(int bullets)
    {
        if (clip==0)return -1;
        if (!SquibLoad())
        {
            if (clip > 0 && bullets < clip)
            {
                clip = clip - bullets;
                return await Task.FromResult(clip);
            }
            else if (clip > 0 && bullets > clip)
            {
                var bulletsFired = clip;
                clip=0;
                return await Task.FromResult(bulletsFired);
            }
            else
            {
                return -1;
            }
        }
        return 0;
    }

    public async Task<int> GetCurrentClip()
    {
        return await Task.FromResult(clip);
    }

    public async Task<int> Reload(int bullets)
    {
        if(( clip + bullets) > magazineSize) 
        {
            clip= magazineSize;
        }
        else
        {
            clip=clip + bullets;
        }
        return await Task.FromResult(clip);
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
    public async Task<bool> Unsquib()
    {
        squibloaded = false;
        return await Task.FromResult(!squibloaded);
    }

    public async Task<int> SetMagazineSize(int size)
    {
        magazineSize = size;
        return await Task.FromResult(magazineSize);
    }
}