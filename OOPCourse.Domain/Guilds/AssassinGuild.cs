using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPCourse.Domain.Guilds
{
    public class AssassinGuild
    {
        private readonly IAssassinsRepo _assassinsRepo;

        public AssassinGuild(IAssassinsRepo assassinsRepo)
        {
            _assassinsRepo = assassinsRepo;
        }

        public List<Assassin> GetAssassins()
        {
            return _assassinsRepo.Assassins
                .Where(a => a.Status != false).Take(4).ToList();
        }

        public Assassin GetAssassin(double reward)
        {
            if (reward <= 0)
                throw new ArgumentException();
            var temp = _assassinsRepo.Assassins
                .Take(4)
                .FirstOrDefault(a => a.Status != false
                                     && (a.LowRewardBound <= reward && reward <= a.HighRewardBound));
            if (temp is null)
                throw new NullReferenceException();
            UpdateAssassinStatus(temp);
            return temp;
        }

        private void UpdateAssassinStatus(Assassin assassin)
        {
            var temp = _assassinsRepo.Assassins.FirstOrDefault(a => a.Name == assassin.Name);
            temp.Status = false;
            _assassinsRepo.Save();
        }
    }
}
