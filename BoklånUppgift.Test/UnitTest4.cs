using BoklånUppgift.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoklånUppgift.Test
{
    public class UnitTest4
    {
        public class SignInManagerTests
        {
            private readonly Mock<SignInManager<RentalUser>> _signInManagerMock;
            private readonly Mock<UserManager<RentalUser>> _userManagerMock;

            public SignInManagerTests()
            {
                _userManagerMock = new Mock<UserManager<RentalUser>>(
                    new Mock<IUserStore<RentalUser>>().Object,
                    null, null, null, null, null, null, null, null);

                _signInManagerMock = new Mock<SignInManager<RentalUser>>(
                    _userManagerMock.Object,
                    new Mock<IHttpContextAccessor>().Object,
                    new Mock<IUserClaimsPrincipalFactory<RentalUser>>().Object,
                    null, null, null, null);
            }

            [Fact]
            public async Task SignInAsync_ShouldSignInUser()
            {
                // Arrange
                var user = new RentalUser { UserName = "testuser", Email = "testuser@example.com" };
                _userManagerMock.Setup(u => u.FindByEmailAsync(user.Email)).ReturnsAsync(user);
                _signInManagerMock.Setup(s => s.CheckPasswordSignInAsync(user, "password", false)).ReturnsAsync(SignInResult.Success);

                // Act
                var result = await _signInManagerMock.Object.CheckPasswordSignInAsync(user, "password", false);

                // Assert
                Assert.Equal(SignInResult.Success, result);

                // Verify that SignInAsync was called with the correct parameters
                _signInManagerMock.Verify(s => s.CheckPasswordSignInAsync(user, "password", false), Times.Once);
            }
        }
    }
}

