﻿using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Concrete;
using OOPCourse.Domain.Guilds;
using OOPCourse.Main.Utilities;
using System;

namespace OOPCourse.Main.EventHandlers
{
    internal class FoolHandler
    {
        public static void Communicate(Player player, IFoolsRepo repo)
        {
            var guild = new FoolGuild(repo);
            var fool = guild.GetFool();
            Console.WriteLine("Wandering around u came across your friend. Also he is a member of Fools guild!!\n" +
                $"His is {fool.Type}. And he offer u to work and get salary in size of {fool.Salary}");

            if (!UserInputGetter.GetUsersConfirm("Will u work? "))
            {
                Console.WriteLine("So no problem have nice day!");
                return;
            }

            Console.WriteLine("Thanks that help me!!! There is your reward");
            player.AddMoney(fool.Salary);
        }
    }
}