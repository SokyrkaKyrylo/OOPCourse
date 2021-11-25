using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Concrete;
using OOPCourse.Domain.Guilds;
using OOPCourse.Main.Utilities;
using System;

namespace OOPCourse.Main.EventHandlers
{
    internal class AssassinHandler
    {
        public static bool Communicate(Player player, IAssassinsRepo repo)
        {
            var guild = new AssassinGuild(repo);
            Console.WriteLine("Wandering around u came across a member of Assassins Guild!!\n" +
                "He said that smb want's to kill and offer a help, u only should pay\n");
              
            if (!UserInputGetter.GetUsersConfirm("Do u accept Assassuns guild's offer? "))
                return false;
           
            string input = default;
            double reward = default;
            do
            {
                Console.WriteLine("Enter reward ");
                input = Console.ReadLine();
                if (!double.TryParse(input, out reward))
                {
                    Console.WriteLine("Try again please ");
                }
            } while (!double.TryParse(input, out reward));

            var assassin = guild.GetAssassin(reward);
            if (assassin is null)
            {
                Console.WriteLine("Heh, u want to fool us, so u will met your death earlier, then expect");
                return false;
            }

            if (!player.GetMoney(reward))
            {
                Console.WriteLine("Heh, u want to fool us, so u will met your death earlier, then expect");
                return false;
            }

            Console.WriteLine($"{assassin.Name} will find u and help");
            return true;
        }
    }
}
