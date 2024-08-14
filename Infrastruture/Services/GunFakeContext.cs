using Domain.Entities;
using Domain.Interfaces;

namespace Infrastruture.Services;

public class GunFakeContext : IGunFakeContext
{
    private Gun gun;
    public Gun _gun
    {
        get { return gun; }
        set 
        { 
            if(gun==null)
            {
                gun = value; 
                GetDefaultGun();
            }
            else gun = value; 
        }
    }
    
    public GunFakeContext(Gun newgun)
    {
        _gun = newgun;
    }
    public void GetDefaultGun()
    {
        _gun.Id=1;
        _gun.ModelName="Winchester";
        _gun.MagazineSize=30;
        _gun.Clip=30;
        _gun.SquibLoaded=false;
    }

    public Gun UpdateDefaultGun(Gun gun)
    {
        _gun = gun;
        return _gun;
    }

    public Gun GetGun()
    {
        return _gun;
    }
}
