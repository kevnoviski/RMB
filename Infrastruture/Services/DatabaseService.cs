using Domain.Entities;
using Domain.Interfaces;

namespace Infrastruture.Services;

public class DatabaseService : IDatabaseService
{
    private readonly IGunFakeService _gunFakeService ;
    private static Gun gun;
    public DatabaseService(IGunFakeService gunFakeService)
    {
        _gunFakeService = gunFakeService;
        gun = _gunFakeService.GetDefaultGun();
    }
    public Task<Gun> GetGunAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Gun> LoadDefaulf()
    {
        return Task.FromResult(gun);
    }

    public Task<Gun> UpdateGunAsync(Gun gun)
    {
        throw new NotImplementedException();
    }
}
