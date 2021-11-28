using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
