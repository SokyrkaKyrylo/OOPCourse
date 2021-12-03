using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPCourse.Domain.Guilds
{
    public class NpcGuild<T> where T : class
    {
        public T GetNpc(IEnumerable<T> npcList)
        {
            var random = new Random();
            var id = random.Next(1, npcList.Count());
            return npcList.ElementAt(id);
        }
    }
}
