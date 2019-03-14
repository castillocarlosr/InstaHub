using InstaHub_MVC.Models;
using System;
using Xunit;

namespace InstaHub_Testing
{
    public class ApplicationUserModelTests
    {
        [Fact]
        public void UserIDGetSet()
        {
            ApplicationUser user = new ApplicationUser();
            user.ID = 1;
            Assert.Equal(1, user.ID);
        }

        [Fact]
        public void EmailGetSet()
        {
            ApplicationUser user = new ApplicationUser();
            user.Email = "email@email.com";
            Assert.Equal("email@email.com", user.Email);
        }

        [Fact]
        public void NameGetSet()
        {
            ApplicationUser user = new ApplicationUser();
            user.Name = "John Doe";
            Assert.Equal("John Doe", user.Name);
        }

        [Fact]
        public void AvatarGetSet()
        {
            ApplicationUser user = new ApplicationUser();
            user.Avatar = "profile_pic.jpg";
            Assert.Equal("profile_pic.jpg", user.Avatar);
        }
    }
}
