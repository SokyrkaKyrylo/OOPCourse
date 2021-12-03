using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Concrete;
using OOPCourse.Domain.Guilds;
using OOPCourse.Domain.Models;
using OOPCourse.Main.Utilities;
using System;

namespace OOPCourse.Main.EventHandlers
{
    internal class AssassinHandler : EventHandler
    {
        private IAssassinsRepo _assassinsRepo;

        public AssassinHandler(IAssassinsRepo assassinsRepo)
        {
            _assassinsRepo = assassinsRepo;
        }

        public override bool Communicate(Player player)
        {
            var guild = new AssassinsGuild(_assassinsRepo);
            Console.WriteLine($"Wandering around u came across a member of {AssassinsGuild.GuildName}!!\n" +
                "He said that smb want's to kill and offer a help, u only should pay");

            if (!UserInputGetter.GetUsersConfirm("Do u accept Assassins guild's offer? "))
            {
                Console.WriteLine("See you on cemetery!");
                return false;
            }

            string input = default;
            decimal reward = default;
            do
            {
                Console.Write("Enter reward: ");
                input = Console.ReadLine();
                if (!decimal.TryParse(input, out reward))
                {
                    Console.WriteLine("Try again please");
                }
            } while (!decimal.TryParse(input, out reward));

            Assassin assassin = null;
            try
            {
                assassin = guild.GetAssassin(reward);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong, try to reload program");
                return true;
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
