//write xunit test cases for all the methods in UsersController.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using RealWorld_Api.Models;
using RealWorld_Api.Controllers;
using RealWorld_Api.DBContext;
using RealWorld_Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace RealWorld_Api.Tests
{
    public class UsersControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly RealWorldDbContext _context;
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public UsersControllerTest(WebApplicationFactory<Program> factory)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
             _factory = factory;
            _client = _factory.CreateClient();
        }
/*
        [Fact]
        public async Task GetUsersTest()
        {
            var response = await _client.GetAsync("/api/users");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<User>>(responseString);
            Assert.Equal(2, users.Count);
        }

        [Fact]
        public async Task GetUserTest()
        {
            var response = await _client.GetAsync("/api/users/1");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(responseString);
            Assert.Equal("test1", user.Username);
        }

        [Fact]
        public async Task GetUserTest_NotFound()
        {
            var response = await _client.GetAsync("/api/users/3");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
*/
        [Fact]
        public async Task PostUserTest()
        {
            var user = new User
            {
                Username = "test3",
                Email = "testemail@gm.com",
                Password = "testpassword",
                Bio = "test bio",
                Image = "test image"
            };
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/users", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var newUser = JsonConvert.DeserializeObject<User>(responseString);
            Assert.Equal("test3", newUser.Username);
        }
/*
        [Fact]
        public async Task PutUserTest()
        {
            var user = new User
            {
                Username = "test3",
                Email = "teste@g.com",
                Password = "testpassword",
                Bio = "test bio",
                Image = "test image"
            };
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/users/1", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var updatedUser = JsonConvert.DeserializeObject<User>(responseString);
            Assert.Equal("a", updatedUser.Username);
        }

        [Fact]
        public async Task PutUserTest_NotFound()
        {
            var user = new User
            {
                Username = "test3",
                Email = "tes@gmail.com",
                Password = "testpassword",
                Bio = "test bio",
                Image = "test image"
            };
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/users/3", content);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task DeleteUserTest()
        {
            var response = await _client.DeleteAsync("/api/users/1");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(responseString);
            Assert.Equal("a", user.Username);
        }

        [Fact]
        public async Task DeleteUserTest_NotFound()
        {
            var response = await _client.DeleteAsync("/api/users/3");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task LoginTest()
        {
            var user = new User
            {
                Email = "tet@test.com",
                Password = "testpassword"
            };
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/users/login", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var loggedUser = JsonConvert.DeserializeObject<User>(responseString);
            Assert.Equal("a", loggedUser.Username);
        }

        [Fact]
        public async Task LoginTest_BadRequest()
        {
            var user = new User
            {
                Email = "etest@test.com",
                Password = "testpassword"
            };
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/users/login", content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task LoginTest_Unauthorized()
        {
            var user = new User
            {
                Email = "test@email.com",
                Password = "testpassword"
            };
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/users/login", content);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task RegisterTest()
        {
            var user = new User
            {
                Username = "test3",
                Email = "test@email.com",
                Password = "testpassword"
            };
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/users", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var newUser = JsonConvert.DeserializeObject<User>(responseString);
            Assert.Equal("test3", newUser.Username);
        }

        [Fact]
        public async Task RegisterTest_BadRequest()
        {
            var user = new User
            {
                Username = "test3",
                Email = "test@email.com",
                Password = "testpassword"
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/users", content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task RegisterTest_Unauthorized()
        {
            var user = new User
            {
                Username = "test3",
                Email = "test@email.com",
                Password = "testpassword"
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/users", content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }*/
    }
}