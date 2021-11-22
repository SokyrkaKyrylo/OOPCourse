using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPCourse.Domain.Abstract;

namespace OOPCourse.Domain.Concrete
{
    public class Assassin : IAssassin
    {
        public string Name { get; set; }
        public double RewardLowBound { get; set; }
        public double RewardHighBound { get; set; }
        public bool Status { get; set; }
        public bool MakeContract(double reward)
        {
            if (reward < 0)
                throw new ArgumentException();
            return reward > RewardLowBound && RewardHighBound > reward;
        }
    }
}
