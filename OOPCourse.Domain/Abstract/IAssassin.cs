using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourse.Domain.Abstract
{
    public interface IAssassin
    {
        string Name { get; }
        double RewardLowBound { get; }
        double RewardHighBound { get;}
        bool Status { get; }
        bool MakeContract(double reward);
    }
}
