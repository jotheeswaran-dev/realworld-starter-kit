using System.Security.Cryptography.X509Certificates;
namespace RealWorld_Api.Helpers
{
    public class PasswordHasher: IPasswordHasher
    {
        //create password hasher class
        public string Hash(string password)
        {
            //create salt
            var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            //hash password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            //return hashed password
            return hashedPassword;
        }

        public bool CheckPassword(string password, string hash)
        {
            //check password
            var validPassword = BCrypt.Net.BCrypt.Verify(password, hash);
            //return valid password
            return validPassword;
        }
    }
    
    public interface IPasswordHasher
    {
        //create interface for password hasher
        string Hash(string password);
        bool CheckPassword(string password, string hash);
        
    }
}