using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Models;
using System.Collections.Generic;

namespace OOPCourse.Domain.Concrete
{
    public class ThievesRepo : IThievesRepo
    {
        private ApplicationContext _context;

        public ThievesRepo(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Thief> Thieves => _context.Thieves;
    }
}
