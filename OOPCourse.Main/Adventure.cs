using OOPCourse.Domain;
using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Concrete;
using OOPCourse.Main.EventHandlers;
using System;

namespace OOPCourse.Main
{
    internal class Adventure
    {               
        private NpcRepo _npcRepo;

        public Adventure(NpcRepo npcRepo)
        {
            _npcRepo = npcRepo;
        }

        public void Start()
        {
            string input = default;
            do
            {
                var player = new Player(100);
                Console.WriteLine("Hello to Ankh-Morpork");
                Console.WriteLine($"In the start of the game have {player.Purse} dollars");
                Console.WriteLine("Have a nice adventure, stranger!");
                while (GenerateEvent(player))
                {
                    Console.WriteLine(String.Format("Your purse {0:0.##}", player.Purse));
                };
                Console.WriteLine("YOU DIED");
                Console.WriteLine("Do u wanna to try again? (Any/No)");
                input = Console.ReadLine();
            }
            while (input != "No");            
        }

        private bool GenerateEvent(Player player)
        {
            var random = new Random();
            switch (random.Next(1,4))
            {
                case 1:
                    return AssassinHandler.Communicate(player, _npcRepo);
                case 2:
                    return ThiefHandler.Communicate(player, _npcRepo);
                case 3:
                    return BeggarHandler.Communicate(player, _npcRepo);
                case 4:
                    FoolHandler.Communicate(player, _npcRepo);
                    return true;
            }
            return true;
        }
    }
}
