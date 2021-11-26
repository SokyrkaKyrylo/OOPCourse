using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Models;
using System;
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

        public Assassin GetAssassin(double reward)
        {
            if (reward <= 0)
                throw new ArgumentException();
            var temp = _assassinsRepo.Assassins
                .FirstOrDefault(a => a.Status != false
                                     && (a.LowRewardBound <= reward && reward <= a.HighRewardBound));
            if (temp is null)
                return null;
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
