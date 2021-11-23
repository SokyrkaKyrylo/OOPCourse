using OOPCourse.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPCourse.Domain.Models;

namespace OOPCourse.Domain.Abstract
{
    public interface IAssassinsRepo
    {
        IEnumerable<Assassin> Assassins { get; } 
    }
}
