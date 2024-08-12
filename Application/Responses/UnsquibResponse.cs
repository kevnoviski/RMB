namespace Application.Responses;

public class UnsquibResponse : BaseResponse
{
    public bool Squibloaded{get; set;}
    public UnsquibResponse(int statusCode, bool squibloaded, string message = null) : base(statusCode, message)
    {
        Squibloaded = squibloaded;
    }
}