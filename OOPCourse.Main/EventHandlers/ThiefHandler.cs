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

        public ThiefHandler(IThievesRepo thievesRepo)
        {
            _thievesRepo = thievesRepo;
        }

        public override bool Communicate(Player player)
        {            
            NpcGuild<Thief> guild = new ThievesGuild();
            Thief thief = null;

            try
            {
                thief = guild.GetNpc(_thievesRepo.Thieves);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong, try to reload program");
                return true;
            }

            if (thief == null)
                return true;

            Console.WriteLine($"Wandering around u came across a member of {ThievesGuild.GuildName}!\n" +
                $"My name is {thief.Name}. U should pay a fee in size of {ThievesGuild.StandardFee} AM$");

            if (!UserInputGetter.GetUsersConfirm("Will u pay? "))
            {
                Console.WriteLine("Hmm, the next time I\'ll see you on cemetery");
                return false;
            }

            if (!player.GetMoney(ThievesGuild.StandardFee))
            {
                Console.WriteLine("Heh, as I understand, U decide to treat us. It was a mistake");
                return false;
            }

            Console.WriteLine("It's a great pleasure to deal with u");
            return true;
        }
    }
}
