using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Concrete;
using OOPCourse.Domain.Guilds;
using OOPCourse.Domain.Models;
using OOPCourse.Main.Utilities;
using System;

namespace OOPCourse.Main.EventHandlers
{
    internal class ThiefHandler : EventHandler
    {
        private IThievesRepo _thievesRepo;
        private int _numberOfThefts;

        public ThiefHandler(IThievesRepo thievesRepo, int numberOfThefts)
        {
            _thievesRepo = thievesRepo;
            _numberOfThefts = numberOfThefts;
        }

        public override bool Communicate(Player player)
        {
            if (_numberOfThefts <= 0)
                return true;
            
            var guild = new ThiefGuild(_thievesRepo);
            Thief thief = null;

            try
            {
                thief = guild.GetThief();
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong, try to reload program");
                return true;
            }

            if (thief == null)
                return true;

            Console.WriteLine("Wandering around u came across a member of Thief Guild!\n" +
                $"My name is {thief.Name}. U should pay a fee in size of {ThiefGuild.StandardFee} AM$");

            if (!UserInputGetter.GetUsersConfirm("Will u pay? "))
            {
                Console.WriteLine("Hmm, the next time I\'ll see you on cemetery");
                return false;
            }

            if (!player.GetMoney(ThiefGuild.StandardFee))
            {
                Console.WriteLine("Heh, as I understand, U decide to treat us. It was a mistake");
                return false;
            }

            Console.WriteLine("It's a great pleasure to deal with u");
            return true;
        }
    }
}
