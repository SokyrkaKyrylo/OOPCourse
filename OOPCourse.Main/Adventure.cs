using OOPCourse.Domain.Concrete;
using OOPCourse.Main.EventHandlers;
using System;
using EventHandler = OOPCourse.Main.EventHandlers.EventHandler;

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
                    if ((int)player.Purse == 0)
                        break;
                    Console.WriteLine(String.Format("Your purse {0:0.##} dollars", player.Purse));
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
            EventHandler eventHandler = null;
            switch (random.Next(1, 5))
            {
                case 1:
                    eventHandler = new AssassinHandler();
                    break;
                case 2:
                    eventHandler = new ThiefHandler();
                    break;
                case 3:
                    eventHandler = new BeggarHandler();
                    break;
                case 4:
                    eventHandler = new FoolHandler();
                    break;
            }
            return eventHandler.Communicate(player, _npcRepo);
        }
    }
}
