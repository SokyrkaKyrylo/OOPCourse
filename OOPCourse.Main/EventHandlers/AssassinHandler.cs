using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Concrete;
using OOPCourse.Domain.Guilds;
using OOPCourse.Domain.Models;
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
                "He said that smb want's to kill and offer a help, u only should pay");              
            if (!UserInputGetter.GetUsersConfirm("Do u accept Assassuns guild's offer? "))
            {
                Console.WriteLine("See you on cemetry!");
                return false;
            }

            string input = default;
            double reward = default;
            Assassin assassin = null;
            while (true)
            {
                try
                {
                    do
                    {
                        Console.WriteLine("Enter reward ");
                        input = Console.ReadLine();
                        if (!double.TryParse(input, out reward))
                        {
                            Console.WriteLine("Try again please");
                        }
                    } while (!double.TryParse(input, out reward));
                    assassin = guild.GetAssassin(reward);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Reward cannot be less than zero");
                    continue;
                }
                break;
            }
          
            if (assassin is null)
            {
                Console.WriteLine("Sorry, but we don't have killer who will make this job for this reward");
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
