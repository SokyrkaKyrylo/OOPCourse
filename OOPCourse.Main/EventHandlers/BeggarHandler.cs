using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Concrete;
using OOPCourse.Domain.Guilds;
using OOPCourse.Main.Utilities;
using System;

namespace OOPCourse.Main.EventHandlers
{
    internal class BeggarHandler
    {
        public static bool Communicate(Player player, IBeggarsRepo repo)
        {
            var guild = new BeggarGuild(repo);
            var beggar = guild.GetBeggar();
            Console.WriteLine("Wandering around u came across a member of Begger Guild!!\n" +
                $"He is a {beggar.Type}. and he ask for some help is size of {beggar.Fee}");

            if (!UserInputGetter.GetUsersConfirm("Will u help him? "))
            {
                Console.WriteLine("Ough, so from this time i'll chasing u and nobody will never talk to u");
                return false;
            }

            if (!player.GetMoney(beggar.Fee))
            {
                Console.WriteLine("Great try. So from this time i'll chasing u and nobody will never talk to u");
                return false;
            }

            Console.WriteLine("Thank u so much. Let God bless your soul. ");
            return true;
        }
    }
}

