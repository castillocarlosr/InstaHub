using InstaHub_MVC.Models;
using System;
using Xunit;

namespace InstaHub_Testing
{
    public class MessageModelTests
    {
        [Fact]
        public void IDGetSet()
        {
            Message message = new Message();
            message.ID = 1;
            Assert.Equal(1, message.ID);
        }

        [Fact]
        public void UserNameGetSet()
        {
            Message message = new Message();
            message.UserName = "KeithMagnuson3@email.com";
            Assert.Equal("KeithMagnuson3@email.com", message.UserName);
        }

        [Fact]
        public void GroupNameGetSet()
        {
            Message message = new Message();
            message.GroupName = "Chicago Blackhaws Fans";
            Assert.Equal("Chicago Blackhaws Fans", message.GroupName);
        }

        [Fact]
        public void ValueGetSet()
        {
            Message message = new Message();
            message.Value = "Hello world!";
            Assert.Equal("Hello world!", message.Value);
        }

        [Fact]
        public void TimestampGetSet()
        {
            Message message = new Message();
            DateTime time = DateTime.Now;
            message.Timestamp = time;
            Assert.Equal(time, message.Timestamp);
        }
    }
}
