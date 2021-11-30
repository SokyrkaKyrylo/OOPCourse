using OOPCourse.Domain.Concrete;

namespace OOPCourse.Main.EventHandlers
{
    internal abstract class EventHandler
    {
        public abstract bool Communicate(Player player);
    }
}
