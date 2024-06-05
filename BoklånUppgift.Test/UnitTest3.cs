using BoklånUppgift.Data;
using BoklånUppgift.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BoklånUppgift.Test
{
    public class UnitTest3 : IDisposable
    {
        private static DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "StudentDbTest")
            .Options;

        ApplicationDbContext context;


        public UnitTest3()
        {
            context = new ApplicationDbContext(dbContextOptions);
            context.Database.EnsureCreated();

            //Seeda databasen
            SeedDatabase();

        }

        private void SeedDatabase()
        {
            var hasher = new PasswordHasher<RentalUser>();
            List<RentalUser> rentalUsers = new List<RentalUser>()
            {
                new RentalUser()

            {

                  FirstName = "System",
                  LastName = "Admin",
                  Email = "admin@email.com",
                  NormalizedEmail = "ADMIN@EMAIL.COM",
                  UserName = "admin@email.com",
                  NormalizedUserName = "ADMIN@EMAIL.COM",
                  PasswordHash = hasher.HashPassword(null, "Test1234!"),
                  EmailConfirmed = true,
                  Id = "1"



                }

            };
            context.Users.AddRange(rentalUsers);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
        [Fact]
        public void FindBookSuccess()
        {
            //Arrange
            RentalUser rentalUser;

            //Act
            rentalUser = context.Users.Find(1);

            //Assert
            Assert.Equal("Bok ett", rentalUser.Email);
        }
        //        [InlineData(new string[] { "A", "B" }, "A,B")]

        //        [Theory]

        //        public void TestMultipleStringConcatWithComma(string[] strings, string expectedResult)
        //        {   //Arrange
        //            Login user = new RentalUser();
        //            string result;
        //            //Act
        //            result = user.
        //            //Assert
        //            Assert.Equal(result, expectedResult);
        //        }
        //    }
        //}
        //    }
        //}
    }
}