using OOPCourse.Domain;
using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Concrete;
using OOPCourse.Main.EventHandlers;
using System;

namespace OOPCourse.Main
{
    internal class Adventure
    {
        delegate bool AssassinHandler(Player player, IAssassinsRepo assassins);
        event AssassinHandler CommunicateWithAssassins;

        delegate bool ThiefHandler(Player player, IThievesRepo thieves);
        event ThiefHandler CommunicateWithThief;

        delegate bool FoolsHandler(Player player, IFoolsRepo fools);
        event FoolsHandler CommunicateWithFool;

        delegate bool BeggarsHandler(Player player, IBeggarsRepo beggars);
        event BeggarsHandler CommunicateWithBeggar;

        private NpcRepo _npcRepo;

        public Adventure(NpcRepo npcRepo)
        {
            _npcRepo = npcRepo;
            CommunicateWithAssassins += AssassinEventHandler.Communicate;
        }

        public void Start()
        {
            var player = new Player(100);

            Console.WriteLine("Hello to Ankh-Morpork");
            Console.WriteLine($"In the start of the game have {player.Purse} dollars");
            Console.WriteLine("Have a nice adventure, stranger!");
            GenerateEvent(player);
        }

        private void GenerateEvent(Player player)
        {
            var random = new Random();
            switch (1)
            {
                case 1:
                    CommunicateWithAssassins?.Invoke( player, _npcRepo);
                    break;
                case 2:
                    CommunicateWithThief?.Invoke(player, _npcRepo);
                    break;
                case 3:
                    CommunicateWithFool?.Invoke(player, _npcRepo);
                    break;
                case 4:
                    CommunicateWithBeggar?.Invoke(player, _npcRepo);
                    break;
                default:
                    break;
            }
        }
    }
}
