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
        public void UserIDGetSet()
        {
            Message message = new Message();
            message.UserID = 1;
            Assert.Equal(1, message.UserID);
        }

        [Fact]
        public void GroupIDGetSet()
        {
            Message message = new Message();
            message.GroupID = 1;
            Assert.Equal(1, message.GroupID);
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
