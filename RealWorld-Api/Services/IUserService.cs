using System.Threading.Tasks;
using RealWorld_Api.Models.Requests;
using RealWorld_Api.Models.Responses;

namespace RealWorld_Api.Services
{
    public interface IUserService
    {
        //create interface for user service
        Task<UserResponse> RegisterUser(RegisterUserRequest request);
        Task<UserResponse> LoginUser(LoginUserRequest request);
        Task<UserResponse> GetCurrentUser();
        Task<UserResponse> UpdateUser(UpdateUserRequest request);

    }
}