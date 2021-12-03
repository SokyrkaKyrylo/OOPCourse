using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace OOPCourse.Domain.Guilds
{
    public class AssassinsGuild
    {
        private readonly IAssassinsRepo _assassinsRepo;

        public AssassinsGuild(IAssassinsRepo assassinsRepo)
        {
            _assassinsRepo = assassinsRepo;
        }

        public List<Assassin> GetAssassins()
        {
            return _assassinsRepo.Assassins
                .Where(a => a.Status).Take(4).ToList();
        }

        public Assassin GetAssassin(decimal reward)
        {
            if (reward <= 0)
                return null;
            var temp = _assassinsRepo.Assassins
                .Take(4)
                .FirstOrDefault(a => a.Status
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
