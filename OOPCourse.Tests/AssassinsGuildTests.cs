using Moq;
using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Guilds;
using OOPCourse.Domain.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace OOPCourse.Tests
{
    public class AssassinsGuildTests
    {

        [Fact]
        public void GetAssassin_WhenRewardLessThanZero_ReturnNull()
        {
            var mock = new Mock<IAssassinsRepo>();
            var guild = new AssassinGuild(mock.Object);
            Assert.Null(guild.GetAssassin(-5));
        }

        [Fact]
        public void GetAssassin_WhenRewardDoesntMatch_ReturnNull()
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

            var guild = new AssassinGuild(mock.Object);

            Assert.Null(guild.GetAssassin(5));
        }

        [Fact]
        public void GetAssassin_WhenAssassinWithSuitableRewardExists_ReturnAAssassin()
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
            var guild = new AssassinGuild(mock.Object);

            var res = guild.GetAssassin(2);

            Assert.Equal("test1", res.Name);
            Assert.False(res.Status);
        }
    }
}
