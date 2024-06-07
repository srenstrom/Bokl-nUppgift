using BoklånUppgift.Data;
using BoklånUppgift.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace BoklånUppgift.Test
{
    public class UnitTest1
    {
    //        private readonly HttpClient _client;

    //        public UnitTest1()
    //        {
    //            // You can initialize _client in the constructor
    //            _client = new HttpClient();
    //            // Assuming your web application is hosted locally, you can set the base address like this:
    //            _client.BaseAddress = new Uri("https://localhost:7004"); // Adjust the port as per your application's configuration
    //        }

    //        //lokal variabel
    //        private static DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
    //        .UseInMemoryDatabase(databaseName: "StudentDbTest")
    //        .Options;
    //    [Fact]
    //        public async Task Register_ReturnsSuccess()
    //        {
    //            // Arrange
    //            var registerData = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
    //  {
    //new KeyValuePair<string, string>("Input.Email", "newuser@example.com"),
    //new KeyValuePair<string, string>("Input.FirstName", "Johanna"),
    //new KeyValuePair<string, string>("Input.LastName", "Test"),
    //new KeyValuePair<string, string>("Input.Password", "NewPassword123!"),
    //new KeyValuePair<string, string>("Input.ConfirmPassword", "NewPassword123!")
    //  });

    //            // Act
    //            var response = await _client.PostAsync("/Identity/Account/Register", registerData);

    //            // Assert
    //            response.EnsureSuccessStatusCode();
    //            var responseString = await response.Content.ReadAsStringAsync();
    //            Assert.Contains("Confirm your email", responseString);
    //        }
        }
    }
