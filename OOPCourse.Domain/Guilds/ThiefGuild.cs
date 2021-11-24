using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Models;

namespace OOPCourse.Domain.Guilds
{
    public class ThiefGuild
    {
        private const int NumberOfThieves = 6;
        public const double StandardFee = 10;
        private readonly IThievesRepo _thieves;

        public ThiefGuild(IThievesRepo thieves)
        {
            this._thieves = thieves;
        }

        public Thief GetThief()
        {
            var temp = _thieves.Thieves.Take(NumberOfThieves).ToList();
            var random = new Random();
            return temp.FirstOrDefault(t => 
                t.Id.Equals(random.Next(temp.Count)));
        }
    }
}
