using OOPCourse.Domain.Models;
using System.Collections.Generic;

namespace OOPCourse.Domain.Abstract
{
    public interface IBeggarsRepo
    {
        IEnumerable<Beggar> Beggars { get; }
    }
}
