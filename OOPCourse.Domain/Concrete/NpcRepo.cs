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
        private readonly ApplicationContext _application;

        public NpcRepo(ApplicationContext application)
        {
            _application = application;
        }

        public IEnumerable<Assassin> Assassins => _application.Assassins;
        public IEnumerable<Thief> Thieves => _application.Thieves;
        public IEnumerable<Beggar> Beggars => _application.Beggars;
        public IEnumerable<Fool> Fools => _application.Fools;
    }
}
