using System;
using System.Linq;
using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Models;

namespace OOPCourse.Domain.Guilds
{
    public class BeggarGuild
    {
        private readonly IBeggarsRepo _beggars;
        public BeggarGuild(IBeggarsRepo beggars)
        {
            _beggars = beggars;
        }

        public Beggar GetBeggar()
        {
            var temp = _beggars.Beggars.ToList();
            var random = new Random();
            var id = random.Next(1, temp.Count - 1);
            return temp
                .FirstOrDefault(b => b.Id == id);
        }
    }
}
