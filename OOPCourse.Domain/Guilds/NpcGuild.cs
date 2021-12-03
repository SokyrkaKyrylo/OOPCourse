namespace OOPCourse.Domain.Guilds
{
    public abstract class NpcGuild<T> where T : class
    {
        public abstract T GetNpc();
    }
}
