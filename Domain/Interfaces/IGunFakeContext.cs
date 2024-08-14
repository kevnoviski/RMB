using Domain.Entities;

namespace Domain.Interfaces;

public interface IGunFakeContext
{
    Gun GetGun();
    Gun UpdateDefaultGun(Gun gun);
}
