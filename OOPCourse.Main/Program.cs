using System;
using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Concrete;

namespace OOPCourse.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player(100);
            var worker = new DataRepo<IAssassin>();
            var guild = new AssassinGuild(worker);
            var assassins = guild.GetAssassins();
            
        }
    }
}
