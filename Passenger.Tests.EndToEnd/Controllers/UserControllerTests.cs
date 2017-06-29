using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passenger.Api;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class UserControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UserControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                            .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task given_valid_email_user_should_exist()
        {
            var email = "4sobek4@gmail.com";
            var user = await GetUserAsync(email);
            user.Email.ShouldBeEquivalentTo(email);

            //czy odp status http jest typu 200.
            //response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task given_invalid_email_user_should_not_exist()
        {
            var email = "8sobek8@gmail.com";
            var response = await _client.GetAsync($"user/{email}");
            //czy odp status http jest typu 200.
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {           
            var request = new CreateUser
            {
                Email = "test@gmail.com",
                Username = "test",
                Passowrd = "secret"
            };
            var payload = GetPayload(request);
            var response = await _client.PostAsync("user", payload);
            //czy odp status http jest typu 200.
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldAllBeEquivalentTo($"user/{request.Email}"); 

            var user = await GetUserAsync(request.Email);
            user.Email.ShouldBeEquivalentTo(request.Email);
        }

        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await _client.GetAsync($"user/{email}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }

        private static StringContent GetPayload(object data){
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}