using Moq;
using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Guilds;
using OOPCourse.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace OOPCourse.Tests
{
    public class AssassinsGuildTests
    {
        [Fact]
        public void GetAssassins_WhenCalled_ReturnsAListWithAssassins()
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

            var res = guild.GetAssassins();

            Assert.Equal(2, res.Count());
            Assert.Equal("test3", res[1].Name);
        }

        [Fact]
        public void GetAssassin_WhenRewardLessThanZero_ThrowsArgumentExc()
        {
            var mock = new Mock<IAssassinsRepo>();
            var guild = new AssassinGuild(mock.Object);
            Assert.Throws<ArgumentException>(() => guild.GetAssassin(-5));
        }

        [Fact]
        public void GetAssassin_WhenAssassinWithSuitableRewardDoesntExist_ThrowNullReferenceExc()
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

            Assert.Throws<NullReferenceException>(() => guild.GetAssassin(5));
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
