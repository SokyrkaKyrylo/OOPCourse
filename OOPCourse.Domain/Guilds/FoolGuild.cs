using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Models;
using System;
using System.Linq;

namespace OOPCourse.Domain.Guilds
{
    public class FoolGuild : NpcGuild<Fool>
    {
        private readonly IFoolsRepo _fools;
        public FoolGuild(IFoolsRepo fools)
        {
            _fools = fools;
        }
       
        public override Fool GetNpc()
        {
            var random = new Random();
            var id = random.Next(1, _fools.Fools.Count());
            return _fools.Fools.FirstOrDefault(t =>
                t.Id == id);
        }
    }
}
