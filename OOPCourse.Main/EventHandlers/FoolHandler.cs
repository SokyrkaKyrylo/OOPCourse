using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Concrete;
using OOPCourse.Domain.Guilds;
using OOPCourse.Domain.Models;
using OOPCourse.Main.Utilities;
using System;

namespace OOPCourse.Main.EventHandlers
{
    internal class FoolHandler : EventHandler
    {
        private IFoolsRepo _foolsRepo;

        public FoolHandler(IFoolsRepo foolsRepo)
        {
            _foolsRepo = foolsRepo;
        }

        public override bool Communicate(Player player)
        {
            NpcGuild<Fool> guild = new NpcGuild<Fool>();
            Fool fool = null;

            try
            {
                fool = guild.GetNpc(_foolsRepo.Fools);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong, try to reload program");
                return true;
            }

            if (fool == null)
                return true;

            Console.WriteLine($"Wandering around u came across your friend. Also he is a member of {FoolsGuild.GuildName}!!" +
                $"\nHis is {fool.Type}. And he offer u to work and get salary in size of {MoneyConverter.Convert(fool.Salary)}");

            if (!UserInputGetter.GetUsersConfirm("Will u work? "))
            {
                Console.WriteLine("So no problem have nice day!");
                return true;
            }

            Console.WriteLine("Thanks that help me!!! There is your reward.");
            player.AddMoney(fool.Salary);
            return true;
        }
    }
}
