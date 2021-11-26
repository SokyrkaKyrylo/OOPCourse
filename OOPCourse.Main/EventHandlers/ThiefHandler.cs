using OOPCourse.Domain.Concrete;
using OOPCourse.Domain.Guilds;
using OOPCourse.Main.Utilities;
using System;

namespace OOPCourse.Main.EventHandlers
{
    internal class ThiefHandler : EventHandler
    {
        public override bool Communicate(Player player, NpcRepo repo)
        {
            var guild = new ThiefGuild(repo);
            var thief = guild.GetThief();

            if (thief == null)
                return true;

            Console.WriteLine("Wandering around u came across a member of Thief Guild!\n" +
                $"My name is {thief.Name}. U should pay a fee in size of {ThiefGuild.StandardFee} AM$");

            if (!UserInputGetter.GetUsersConfirm("Will u pay? "))
            {
                Console.WriteLine("Hmm, the next time I\'ll see you on cemetry");
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
