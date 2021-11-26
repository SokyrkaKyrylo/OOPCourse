using OOPCourse.Domain.Concrete;
using System;

namespace OOPCourse.Main.EventHandlers
{
    internal class EventHandler
    {
        public virtual bool Communicate(Player player, NpcRepo repo)
        {
            Console.WriteLine("Hello Player");
            return true;
        }
    }
}
