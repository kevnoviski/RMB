namespace Application.Responses;

public class FireResponse : BaseResponse
{
    public int RemainingBullets { get; set; }
    public bool SquibLoadOccurred { get; set; }

    public FireResponse(int statusCode, int remainingBullets, bool squibLoadOccurred, string message = null)
        : base(statusCode, message)
    {
        RemainingBullets = remainingBullets;
        SquibLoadOccurred = squibLoadOccurred;
    }
}