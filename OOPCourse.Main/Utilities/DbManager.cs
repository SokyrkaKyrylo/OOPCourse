using OOPCourse.Domain;
using OOPCourse.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace OOPCourse.Main
{
    public class DbManager
    {
        public static void FeedDb(ApplicationContext context)
        {
            context.Assassins.AddRange(new List<Assassin>
            {
                new Assassin { Name = "Bloody Jack", LowRewardBound = 15, HighRewardBound = 30, Status = true},
                new Assassin { Name = "Strong Garry", LowRewardBound = 20,  HighRewardBound = 40, Status = true},
                new Assassin { Name = "Silly Peter", LowRewardBound = 5, HighRewardBound = 10, Status = true},
                new Assassin { Name = "Cruel Larry", LowRewardBound = 7, HighRewardBound = 15, Status = true},
                new Assassin { Name = "Crazy Ken", LowRewardBound = 10, HighRewardBound = 20, Status = true},
                new Assassin { Name = "Whitehead", LowRewardBound = 16, HighRewardBound = 22, Status = true},
                new Assassin { Name = "Merciless Jo", LowRewardBound = 10, HighRewardBound = 15, Status = true},
                new Assassin { Name = "Pangolin", LowRewardBound = 20, HighRewardBound = 30, Status = true},
            });

            context.Thieves.AddRange(new List<Thief>
            {
                new Thief {Name = "Unfair John"},
                new Thief {Name = "Lucky Jack"},
                new Thief {Name = "Clever Steve"},
                new Thief {Name = "Invisible Rob"},
                new Thief {Name = "One-eyed Garret"},
                new Thief {Name = "Tricky Nicky"},
            });

            context.Beggars.AddRange(new List<Beggar>
            {
                new Beggar { Type = "Twitcher", Fee = 3},
                new Beggar { Type = "Drooler", Fee = 2},
                new Beggar { Type = "Dribbler", Fee = 1},
                new Beggar { Type = "Mumbler", Fee = 1},
                new Beggar { Type = "Mutterer", Fee = 0.9},
                new Beggar { Type = "Walking-Along-Shouters", Fee = 0.8},
                new Beggar { Type = "Demanders of a Chip", Fee = 0.6},
                new Beggar { Type = "People Who Call Other People Jimmy", Fee = 0.5},
                new Beggar { Type = "People Who Need Eightpence For A Meal", Fee = 0.08},
                new Beggar { Type = "People Who Need Tuppence For A Cup Of Tea", Fee = 0.02},
                new Beggar { Type = "People With Placards Saying \"Why lie? I need a beer.\"", Fee = 0},

            });

            context.Fools.AddRange(new List<Fool>
            {
                new Fool { Type = "Muggins", Salary = 0.5},
                new Fool { Type = "Gull", Salary = 1},
                new Fool { Type = "Dupe", Salary = 2},
                new Fool { Type = "Butt", Salary = 3},
                new Fool { Type = "Fool", Salary = 5},
                new Fool { Type = "Tomfool", Salary = 6},
                new Fool { Type = "Stupid fool", Salary = 7},
                new Fool { Type = "Arch fool", Salary = 8},
                new Fool { Type = "Complete fool", Salary = 10},
            });

            context.SaveChangesAsync();
        }

        public static void RefershDb(ApplicationContext context)
        {
            var asssinsToUpdate = context.Assassins.Where(a => !a.Status).ToList();
            asssinsToUpdate.ForEach(a => a.Status = true);
            context.UpdateRange(asssinsToUpdate);
            context.SaveChanges();
        }
    }
}
