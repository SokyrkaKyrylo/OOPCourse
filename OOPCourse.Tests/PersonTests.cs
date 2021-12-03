using OOPCourse.Domain.Concrete;
using System;
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

        [Theory]
        [InlineData(0, 10, 10)]
        [InlineData(10, 10, 20)]

        public void AddMoney_WhenSumIsCorrect_AddSumToPurse(decimal initial, decimal salary, decimal result)
        {
            var p = new Player(initial);
            p.AddMoney(salary);
            Assert.Equal(result, p.Purse);
        }

        [Fact]
        public void GetMoney_WhenSumIsntCorrect_ThrowArgumentException()
        {
            var p = new Player(100);
            Assert.Throws<ArgumentException>(() => p.GetMoney(-5));
        }

        [Theory]
        [InlineData(0, 10)]
        [InlineData(10, 50)]
        public void GetMoney_WhenSumIsMoreThanPurse_ReturnsFalse(decimal purse, decimal fee)
        {
            var p = new Player(purse);
            var result = p.GetMoney(fee);
            Assert.False(result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 5)]
        [InlineData(10, 10)]
        public void GetMoney_WhenSumIsCorrect_ReturnsTrue(decimal purse, decimal fee)
        {
            var p = new Player(purse);
            var result = p.GetMoney(fee);
            Assert.True(result);
        }
    }
}
