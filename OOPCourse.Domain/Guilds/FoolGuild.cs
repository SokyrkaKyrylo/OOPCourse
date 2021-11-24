using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Models;

namespace OOPCourse.Domain.Guilds
{
    public class FoolGuild
    {
        private readonly IFoolsRepo _fools;
        public FoolGuild(IFoolsRepo fools)
        {
            _fools = fools;
        }

        public Fool GetFool()
        {
            var temp = _fools.Fools.ToList();
            var random = new Random();
            var id = random.Next(1, temp.Count);
            return temp.FirstOrDefault(t =>
                t.Id == id);
        }
    }
}
