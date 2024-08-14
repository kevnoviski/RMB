using Application.Contracts;

namespace Application.Services;

public class SquibLoadService : ISquibLoadService
{
    public bool SquibLoadGun(bool curretState)
    {
        if (!curretState)
        {
            Random rnd = new Random();
            curretState = rnd.Next(1, 100) % 2 == 0;
            return curretState;
        }
        return true;
    }
}