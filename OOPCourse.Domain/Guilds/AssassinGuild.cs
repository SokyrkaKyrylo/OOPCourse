using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace OOPCourse.Main
{
    public class AssassinGuild
    {
        private static readonly string _filePath =
            "C:\\Users\\kyrylo.sokyrka\\OOPCourse\\OOPCourse.Domain\\Files\\assassins.json";

        private IDataRepo<IAssassin> _dataRepo;
        private readonly IEnumerable<IAssassin> _lisOfAssassins;

        public AssassinGuild(IDataRepo<IAssassin> jsonWorker)
        {
            _dataRepo = jsonWorker;
            _lisOfAssassins = _dataRepo.LoadListOfObjectFromRepo(_filePath);
        }

        public List<IAssassin> GetAssassins()
        {
            return _lisOfAssassins
                .Where(a => a.Status != false).ToList();
        }

        public IAssassin GetAssassin(double reward)
        {
            if (reward <= 0)
                throw new ArgumentException();
            var temp = _lisOfAssassins
                .FirstOrDefault(a => a.Status != false
                                     && (a.RewardLowBound <= reward && reward <= a.RewardHighBound));
            if (temp is null)
                throw new NullReferenceException();
            UpdateAssassinStatus(temp);
            return temp;
        }

        private void UpdateAssassinStatus(IAssassin assassin)
        {
            var temp = (Assassin)_lisOfAssassins.FirstOrDefault(a => a.Name == assassin.Name);
            temp.Status = false;
        }

    }
}
