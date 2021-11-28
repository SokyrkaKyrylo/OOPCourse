using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Models;
using System;
using System.Collections.Generic;

namespace OOPCourse.Domain.Concrete
{
    public class FoolsRepo : IFoolsRepo
    {
        private ApplicationContext _context;

        public FoolsRepo(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Fool> Fools => _context.Fools;
    }
}
