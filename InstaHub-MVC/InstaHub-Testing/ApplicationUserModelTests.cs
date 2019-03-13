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
            user.UserID = 1;
            Assert.Equal(1, user.UserID);
        }
    }
}
