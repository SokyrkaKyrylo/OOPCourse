using OOPCourse.Domain.Models;

namespace OOPCourse.Domain.Guilds
{
    public class ThievesGuild : NpcGuild<Thief>
    {
        public const decimal StandardFee = 10;

        public const string GuldName =
            "Guild of Thieves, Cutpurses and Allied Trades";
    }
}
