namespace Application.Responses;

public class ReloadResponse : BaseResponse
{
    public int Currentclip { get; set; }   
    public ReloadResponse(int statusCode, int currentClip, string message = null) : base(statusCode, message)
    {
        Currentclip=currentClip;
    }    
}