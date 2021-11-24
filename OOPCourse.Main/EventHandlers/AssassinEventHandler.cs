﻿using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Concrete;
using OOPCourse.Domain.Guilds;
using OOPCourse.Main.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourse.Main.EventHandlers
{
    internal class AssassinEventHandler
    {
        public static bool Communicate(Player player, IAssassinsRepo repo)
        {
            var guild = new AssassinGuild(repo);
            Console.WriteLine("Wandering around u came across a member of Assassins Guild!!\n" +
                "He said that smb want's to kill and offer a help, u only should pay\n" +
                "There a list of assisins, who can make all dirty work instead of u");
            
            if (!UserInputGetter.GetUsersConfirm("Do u accept Assassuns guild's offer? "))
                return false;
            var listOfAssassins = guild.GetAssassins();
            foreach (var a in listOfAssassins)
                Console.WriteLine($"Assasin reward - [{a.LowRewardBound} - {a.HighRewardBound}");
            
            string input = default;
            int reward = default;            
            do
            {
                Console.WriteLine("Enter reward ");
                input = Console.ReadLine();
                if (!int.TryParse(input, out reward))
                {
                    Console.WriteLine("Try again please ");
                }
            } while (!int.TryParse(input, out reward));

            var assassin = guild.GetAssassin(reward);
            if (assassin is null)
            {                
                Console.WriteLine("Heh, u want to fool us, so u will met your death earlier, then excpect");
                return false;
            }

            if (!player.GetMoney(reward))
            {
                Console.WriteLine("Heh, u want to fool us, so u will met your death earlier, then excpect");
                return false;
            }

            Console.WriteLine($"{assassin.Name} will find u and help");
            return true;
        }
    }
}