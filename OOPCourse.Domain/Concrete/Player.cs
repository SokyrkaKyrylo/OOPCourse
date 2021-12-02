using System;

namespace OOPCourse.Domain.Concrete
{
    public class Player
    {
        public Player(decimal purse)
        {
            if (purse < 0)
                throw new ArgumentException("Money can not be less than zero");
            Purse = purse;
        }

        public decimal Purse { get; private set; }

        public void AddMoney(decimal sum)
        {
            if (sum < 0)
                throw new ArgumentException("Money can not be less than zero");
            Purse += sum;
        }

        public bool GetMoney(decimal sum)
        {
            if (sum < 0)
                throw new ArgumentException("Money can not be less than zero");
            if (Purse < sum)
                return false;
            Purse -= sum;
            return true;
        }
    }
}
