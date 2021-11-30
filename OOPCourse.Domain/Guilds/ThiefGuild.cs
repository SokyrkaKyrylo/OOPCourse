﻿using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Models;
using System;
using System.Linq;

namespace OOPCourse.Domain.Guilds
{
    public class ThiefGuild
    {
        public const double StandardFee = 10;

        private const int NumberOfThieves = 6;
        private readonly IThievesRepo _thieves;

        public ThiefGuild(IThievesRepo thieves)
        {
            this._thieves = thieves;
        }

        public Thief GetThief()
        {
            var temp = _thieves.Thieves.Take(NumberOfThieves).ToList();
            var random = new Random();
            var id = random.Next(1, NumberOfThieves);
            return temp.FirstOrDefault(t =>
                t.Id == id);
        }
    }
}
