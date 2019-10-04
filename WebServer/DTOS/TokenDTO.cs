namespace WebServer.DTOS
{
    // This DTO supposed to be used with authorisation code flow in PostsController.cs/Authorization
    public class TokenDTO
    {
        public string access_token { get; }
    }
}