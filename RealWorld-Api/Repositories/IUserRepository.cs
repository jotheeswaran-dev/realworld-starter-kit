
//create interface for user repository
using System.Threading.Tasks;
using RealWorld_Api.Models.Requests;
using RealWorld_Api.Models.Responses;

namespace RealWorld_Api.Repositories
{
    public interface IUserRepository
    {
        Task<UserResponse> RegisterUser(RegisterUserRequest request);
        Task<UserResponse> LoginUser(LoginUserRequest request);
        Task<UserResponse> GetCurrentUser();
        Task<UserResponse> UpdateUser(UpdateUserRequest request);
    }
}