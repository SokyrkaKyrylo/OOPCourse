using System;
using System.Net.Http.Headers;
using OOPCourse.Domain.Concrete;
using Xunit;

namespace OOPCourse.Tests
{
    public class PersonTests
    {
        [Fact]
        public void AddMoney_WhenSumIsntCorrect_ThrowArgumentException()
        {
            var p = new Player(100);
            Assert.Throws<ArgumentException>(() => p.AddMoney(-5));
        }

        [Fact]
        public void AddMoney_WhenSumIsCorrect_AddSumToPurse()
        {
            var p = new Player(50);
            p.AddMoney(10);
            Assert.Equal(60, p.Purse);
        }

        [Fact]
        public void GetMoney_WhenSumIsntCorrect_ThrowArgumentException()
        {
            var p = new Player(100);
            Assert.Throws<ArgumentException>(() => p.GetMoney(-5));
        }

        [Fact]
        public void GetMoney_WhenSumIsMoreThanPurse_ReturnsFalse()
        {
            var p = new Player(50);
            var result = p.GetMoney(60);
            Assert.False(result);
        }

        [Fact]
        public void GetMoney_WhenSumIsMoreThanPurse_ReturnsTrue()
        {
            var p = new Player(50);
            var result = p.GetMoney(10);
            Assert.True(result);
        }
    }
}
