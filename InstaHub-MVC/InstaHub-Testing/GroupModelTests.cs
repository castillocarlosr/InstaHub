using InstaHub_MVC.Models;
using System;
using Xunit;

namespace InstaHub_Testing
{
    public class GroupModelTests
    {
        [Fact]
        public void IDGetSet()
        {
            Group group = new Group();
            group.ID = 1;
            Assert.Equal(1, group.ID);
        }

        [Fact]
        public void NameGetSet()
        {
            Group group = new Group();
            group.Name = "SeaTac Devs";
            Assert.Equal("SeaTac Devs", group.Name);
        }

        [Fact]
        public void AvatarGetSet()
        {
            Group group = new Group();
            group.GroupType = GroupType.DM;
            Assert.Equal(GroupType.DM, group.GroupType);
        }
    }
}
