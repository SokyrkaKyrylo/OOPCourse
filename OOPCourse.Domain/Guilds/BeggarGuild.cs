﻿using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Models;
using System;
using System.Linq;

namespace OOPCourse.Domain.Guilds
{
    public class BeggarGuild : NpcGuild<Beggar>
    {
        private readonly IBeggarsRepo _beggars;
        public BeggarGuild(IBeggarsRepo beggars)
        {
            _beggars = beggars;
        }

        public override Beggar GetNpc()
        {
            var random = new Random();
            var id = random.Next(1, _beggars.Beggars.Count());
            return _beggars.Beggars
                .FirstOrDefault(b => b.Id == id);
        }
    }
}
