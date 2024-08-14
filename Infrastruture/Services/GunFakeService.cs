using Domain.Entities;
using Domain.Interfaces;

namespace Infrastruture.Services;

public class GunFakeService : IGunFakeService
{
    public Gun GetDefaultGun()
    {
        return new Gun()
        {
            Id=1,
            ModelName="Winchester", 
            MagazineSize=30,
            Clip=30,
            SquibLoaded=false
        };
    }
}
