using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourse.Domain.Abstract
{
    interface IPlayer
    {
        double Purse { get; }
        void AddMoney(double sum);
        double GetMoney(double sum);
    }
}
