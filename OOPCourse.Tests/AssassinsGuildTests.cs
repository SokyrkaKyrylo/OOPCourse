using Moq;
using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Guilds;
using OOPCourse.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace OOPCourse.Tests
{
    public class AssassinsGuildTests
    {
        private AssassinsGuild _guild;

        public AssassinsGuildTests()
        {
            var mock = new Mock<IAssassinsRepo>();
            mock.Setup(m =>
                    m.Assassins)
                .Returns(new List<Assassin>
                {
                    new Assassin {Name = "test1", LowRewardBound= 1, HighRewardBound = 2, Status = true},
                    new Assassin {Name = "test2", LowRewardBound = 3, HighRewardBound = 4, Status = false},
                    new Assassin {Name = "test3", LowRewardBound = 1, HighRewardBound = 2, Status = true}
                });

            _guild = new AssassinsGuild(mock.Object);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(5)]
        [InlineData(3)]
        public void GetAssassin_WhenRewardIsIncorect_ReturnNull(int input)
        {
            Assert.Null(_guild.GetAssassin(input));
        }

        [Fact]
        public void GetAssassin_WhenAssassinWithSuitableRewardExists_ReturnAAssassin()
        {
            var res = _guild.GetAssassin(2);

            Assert.Equal("test1", res.Name);
            Assert.False(res.Status);
        }       
    }
}
