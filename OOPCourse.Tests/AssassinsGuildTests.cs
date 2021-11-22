using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Concrete;
using OOPCourse.Main;

namespace OOPCourse.Tests
{
    public class AssassinsGuildTests
    {
        [Fact]
        public void GetAssassins_WhenCalled_ReturnsAListWithAssassins()
        {
            var mock = new Mock<IDataRepo<IAssassin>>();
            mock.Setup(m =>
                    m.LoadListOfObjectFromRepo(It.IsAny<string>()))
                .Returns(new List<IAssassin>
                {
                    new Assassin {Name = "test1", RewardLowBound = 1, RewardHighBound = 2, Status = true},
                    new Assassin {Name = "test2", RewardLowBound = 3, RewardHighBound = 4, Status = false},
                    new Assassin {Name = "test3", RewardLowBound = 1, RewardHighBound = 2, Status = true}
                });

            var guild = new AssassinGuild(mock.Object);

            var res = guild.GetAssassins();

            Assert.Equal(2, res.Count());
            Assert.Equal("test3", res[1].Name);
        }

        [Fact]
        public void GetAssassin_WhenRewardLessThanZero_ThrowsArgumentExc()
        {
            var mock = new Mock<IDataRepo<IAssassin>>();
            var guild = new AssassinGuild(mock.Object);
            Assert.Throws<ArgumentException>(() => guild.GetAssassin(-5));
        }

        [Fact]
        public void GetAssassin_WhenAssassinWithSuitableRewardDoesntExist_ThrowNullReferenceExc()
        {
            var mock = new Mock<IDataRepo<IAssassin>>();
            mock.Setup(m =>
                    m.LoadListOfObjectFromRepo(It.IsAny<string>()))
                .Returns(new List<IAssassin>
                {
                    new Assassin {Name = "test1", RewardLowBound = 1, RewardHighBound = 2, Status = true},
                    new Assassin {Name = "test2", RewardLowBound = 3, RewardHighBound = 4, Status = false},
                    new Assassin {Name = "test3", RewardLowBound = 1, RewardHighBound = 2, Status = true}
                });

            var guild = new AssassinGuild(mock.Object);

            Assert.Throws<NullReferenceException>(() => guild.GetAssassin(5));
        }

        [Fact]
        public void GetAssassin_WhenAssassinWithSuitableRewardExists_ReturnAAssassin()
        {
            var mock = new Mock<IDataRepo<IAssassin>>();
            mock.Setup(m =>
                    m.LoadListOfObjectFromRepo(It.IsAny<string>()))
                .Returns(new List<IAssassin>
                {
                    new Assassin {Name = "test1", RewardLowBound = 1, RewardHighBound = 2, Status = true},
                    new Assassin {Name = "test2", RewardLowBound = 3, RewardHighBound = 4, Status = false},
                    new Assassin {Name = "test3", RewardLowBound = 1, RewardHighBound = 2, Status = true}
                });

            var guild = new AssassinGuild(mock.Object);

            var res = guild.GetAssassin(2);

            Assert.Equal("test1", res.Name);
            Assert.False(res.Status);
        }
    }
}
