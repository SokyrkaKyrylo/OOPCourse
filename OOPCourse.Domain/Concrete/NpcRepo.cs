using OOPCourse.Domain.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPCourse.Domain.Models;

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
