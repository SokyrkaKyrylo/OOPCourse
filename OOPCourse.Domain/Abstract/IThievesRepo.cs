using OOPCourse.Domain.Models;
using System.Collections.Generic;

namespace OOPCourse.Domain.Abstract
{
    public interface IThievesRepo
    {
        IEnumerable<Thief> Thieves { get; }
    }
}
