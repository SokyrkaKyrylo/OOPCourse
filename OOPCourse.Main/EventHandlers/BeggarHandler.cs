using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Concrete;
using OOPCourse.Domain.Guilds;
using OOPCourse.Domain.Models;
using OOPCourse.Main.Utilities;
using System;

namespace OOPCourse.Main.EventHandlers
{
    internal class BeggarHandler : EventHandler
    {
        private IBeggarsRepo _beggarsRepo;

        public BeggarHandler(IBeggarsRepo beggarsRepo)
        {
            _beggarsRepo = beggarsRepo;
        }

        public override bool Communicate(Player player)
        {
            NpcGuild<Beggar> guild = new BeggarsGuild();
            Beggar beggar = null;

            try
            {
                beggar = guild.GetNpc(_beggarsRepo.Beggars);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong, try to reload program");
                return true;
            }

            if (beggar == null)
            {
                return true;
            }

            Console.WriteLine($"Wandering around u came across a member of {BeggarsGuild.GuildName}" +
                $"!!\nHe is a {beggar.Type}. and he ask for some help is size of {MoneyConverter.Convert(beggar.Fee)}");

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

            Console.WriteLine("Thank u so much. Let God bless your soul.");
            return true;
        }
    }
}

