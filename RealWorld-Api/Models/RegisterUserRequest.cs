using System.Security.Cryptography.X509Certificates;
//create class for RegisterUserRequest
namespace RealWorld_Api.Models.Requests
{
    public class RegisterUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
//create class for UpdateUserRequest
namespace RealWorld_Api.Models.Requests
{
    public class UpdateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
    }
}
//create class for LoginUserRequest
namespace RealWorld_Api.Models.Requests
{
    public class LoginUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

