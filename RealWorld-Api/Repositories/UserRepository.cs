
//create class for user repository
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RealWorld_Api.Models.Requests;
using RealWorld_Api.Models.Responses;
using RealWorld_Api.Services;
using Microsoft.EntityFrameworkCore;
using RealWorld_Api.Models;
using RealWorld_Api.DBContext;
using  RealWorld_Api.Helpers;

namespace RealWorld_Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RealWorldDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        //private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(RealWorldDbContext context, IPasswordHasher passwordHasher, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _passwordHasher = passwordHasher;
           // _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserResponse> RegisterUser(RegisterUserRequest request)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (existingUser != null)
            {
                throw new Exception("A user with that email already exists.");
            }

            var newUser = new User
            {
                Email = request.Email,
                Username = request.Username,
                PasswordHash = _passwordHasher.Hash(request.Password)
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            var userResponse = new UserResponse
            {
                User = newUser
            };

            return userResponse;
        }

        public async Task<UserResponse> LoginUser(LoginUserRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                throw new Exception("A user with that email does not exist.");
            }

            var isPasswordValid = _passwordHasher.CheckPassword(request.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                throw new Exception("Invalid password.");
            }

            var userResponse = new UserResponse
            {
                User = user
            };

            return userResponse;
        }

        public async Task<UserResponse> GetCurrentUser()
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == "user@email.com");
            if (user == null)
            {
                throw new Exception("A user with that email does not exist.");
            }

            var userResponse = new UserResponse
            {
                User = user
            };

            return userResponse;
        }

        public async Task<UserResponse> UpdateUser(UpdateUserRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == "user@email.com");
            if (user == null)
            {
                throw new Exception("A user with that email does not exist.");
            }

            user.Email = request.Email ?? user.Email;
            user.Username = request.Username ?? user.Username;
            user.Bio = request.Bio ?? user.Bio;
            user.Image = request.Image ?? user.Image;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            var userResponse = new UserResponse
            {
                User = user
            };

            return userResponse;
        }
    }
}