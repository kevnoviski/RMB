namespace Application.Responses;

public class ClipStatusResponse : BaseResponse
{
    public int CurrentClip { get; set; }

    public ClipStatusResponse(int statusCode, int currentClip, string message = null) 
        : base(statusCode, message)
    {
        CurrentClip = currentClip;
    }
}