using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Concrete;
using OOPCourse.Domain.Guilds;
using OOPCourse.Main.Utilities;
using System;

namespace OOPCourse.Main.EventHandlers
{
    internal class ThiefHandler
    {
        public static bool Communicate(Player player, IThievesRepo repo)
        {
            var guild = new ThiefGuild(repo);
            var thief = guild.GetThief();

            Console.WriteLine("Wandering around u came across a member of Thief Guild!\n" +
                $"My name is {thief.Name}. U should pay a fee in size of {ThiefGuild.StandardFee} AM$");

            if (!UserInputGetter.GetUsersConfirm("Will u pay? "))
            {
                Console.WriteLine("Hmm, the next time I\'ll see you on cemetry");
                return false;
            }

            if (!player.GetMoney(ThiefGuild.StandardFee))
            {
                Console.WriteLine("Heh, as I anderstand u decide to treat us. It was a mistake");
                return false;
            }

            Console.WriteLine("It's a great pleasure to deal with u");
            return true;
        }
    }
}
