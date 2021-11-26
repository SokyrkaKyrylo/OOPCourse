using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Models;
using System.Collections.Generic;

namespace OOPCourse.Domain.Concrete
{
    public class NpcRepo : IAssassinsRepo, IThievesRepo, IBeggarsRepo, IFoolsRepo
    {
        private readonly ApplicationContext _context;

        public NpcRepo(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Assassin> Assassins => _context.Assassins;
        public IEnumerable<Thief> Thieves => _context.Thieves;
        public IEnumerable<Beggar> Beggars => _context.Beggars;
        public IEnumerable<Fool> Fools => _context.Fools;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
