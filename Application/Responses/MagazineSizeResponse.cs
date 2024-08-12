namespace Application.Responses;

public class MagazineSizeResponse : BaseResponse
{
    public int MagazineSize { get; set; }
    public MagazineSizeResponse(int statusCode, int magazineSize, string message = null) : base(statusCode, message)
    {
        MagazineSize= magazineSize;
    }
}