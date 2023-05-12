using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
//create User class with email password and username
namespace RealWorld_Api.Models
{
    public class User
    {
         [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string? Bio { get; set; }
        public string? Image { get; set; }
        public string? PasswordHash { get; set; }
    }
}