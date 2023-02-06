using System.Text.Json.Serialization;

namespace APITask.DTO
{
    public class AuthRequestDto
    {
       
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
