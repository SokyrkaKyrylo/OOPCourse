using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Models;
using System;
using System.Linq;

namespace OOPCourse.Domain.Guilds
{
    public class ThiefGuild : NpcGuild<Thief>
    {
        public const decimal StandardFee = 10;
        
        private readonly IThievesRepo _thieves;

        public ThiefGuild(IThievesRepo thieves)
        {
            this._thieves = thieves;
        }

        public override Thief GetNpc()
        {
            var random = new Random();
            var id = random.Next(1, _thieves.Thieves.Count());
            return _thieves.Thieves.FirstOrDefault(t =>
                t.Id == id);
        }
    }
}
