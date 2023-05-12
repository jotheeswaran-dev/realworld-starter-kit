using System;
using System.Threading.Tasks;
using RealWorld_Api.Models.Requests;
using RealWorld_Api.Models.Responses;
using RealWorld_Api.Repositories;

namespace RealWorld_Api.Services
{
public class UserService:IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> RegisterUser(RegisterUserRequest request)
    {
        var user = await _userRepository.RegisterUser(request);
        return user;
    }

    public async Task<UserResponse> LoginUser(LoginUserRequest request)
    {
        var user = await _userRepository.LoginUser(request);
        return user;
    }

    public async Task<UserResponse> GetCurrentUser()
    {
        var user = await _userRepository.GetCurrentUser();
        return user;
    }

    public async Task<UserResponse> UpdateUser(UpdateUserRequest request)
    {
        var user = await _userRepository.UpdateUser(request);
        return user;
    }


}
}