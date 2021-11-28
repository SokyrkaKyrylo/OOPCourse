using OOPCourse.Domain;
using OOPCourse.Domain.Concrete;
using OOPCourse.Main.EventHandlers;
using System;

namespace OOPCourse.Main
{
    internal class Adventure
    {
        private ApplicationContext _context;

        public Adventure(ApplicationContext context)
        {
            _context = context;
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
            switch (random.Next(1, 5))
            {
                case 1:
                    var assassinRepo = new AssassinsRepo(_context);
                    return AssassinHandler.Communicate(player, assassinRepo);
                case 2:
                    var thievesRepo = new ThievesRepo(_context);
                    return ThiefHandler.Communicate(player, thievesRepo);
                case 3:
                    var beggarsRepo = new BeggarsRepo(_context);
                    return BeggarHandler.Communicate(player, beggarsRepo);
                case 4:
                    var foolsRepo = new FoolsRepo(_context);
                    return FoolHandler.Communicate(player, foolsRepo);
            }
            return true;
        }
    }
}
