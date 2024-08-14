
using Domain.Entities;

namespace Domain.Interfaces;
public interface IDatabaseService
{
    Task<Gun> GetGunAsync(int id);
    Task<Gun> UpdateGunAsync(Gun gun);
    Task<Gun> LoadDefaulf();
}
