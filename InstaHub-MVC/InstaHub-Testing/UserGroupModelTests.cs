using InstaHub_MVC.Models;
using System;
using Xunit;

namespace InstaHub_Testing
{
    public class UserGroupModelTests
    {
        [Fact]
        public void UserIDGetSet()
        {
            UserGroup userGroup = new UserGroup();
            userGroup.UserID = 1;
            Assert.Equal(1, userGroup.UserID);
        }

        [Fact]
        public void GroupIDGetSet()
        {
            UserGroup userGroup = new UserGroup();
            userGroup.GroupID = 1;
            Assert.Equal(1, userGroup.GroupID);
        }
    }
}
