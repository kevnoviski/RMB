
using Domain.Entities;

namespace Domain.Interfaces;
public interface IGunRepository
{
    Task<Gun> GetGunAsync();
    Task<Gun> UpdateGunAsync(Gun gun);
}
