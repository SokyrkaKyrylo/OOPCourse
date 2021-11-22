using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPCourse.Domain.Abstract;

namespace OOPCourse.Domain.Concrete
{
    public class Player : IPlayer
    {
        public Player(double purse)
        {
            if (purse < 0)
                throw new ArgumentException("Money can not be less than zero");
            Purse = purse;
        }

        public double Purse { get; private set; }

        public void AddMoney(double sum)
        {
            if (sum < 0)
                throw new ArgumentException("Money can not be less than zero");
            Purse += sum;
        }

        public double GetMoney(double sum)
        {
            if (sum <= 0)
                throw new ArgumentException("Money can not be less than zero");
            if (Purse < sum)
                return 0;
            Purse -= sum;
            return sum;
        }
    }
}
