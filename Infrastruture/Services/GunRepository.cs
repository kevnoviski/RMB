using Domain.Entities;
using Domain.Interfaces;

namespace Infrastruture.Services;

public class GunRepository : IGunRepository
{
    private readonly IGunFakeContext _gunFakeContext ;

    public GunRepository(IGunFakeContext gunFakeContext)
    {
        _gunFakeContext = gunFakeContext;
    }
    public async Task<Gun> GetGunAsync()
    {
        return await Task.FromResult(_gunFakeContext.GetGun());
    }

    public async Task<Gun> UpdateGunAsync(Gun gun)
    {
        return await Task.FromResult(_gunFakeContext.UpdateDefaultGun(gun));
    }
}
