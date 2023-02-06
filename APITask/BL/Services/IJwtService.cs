namespace APITask.BL.Services
{
    public interface IJwtService
    {
        string GetJwtToken(string username, int accountId);
    }
}
