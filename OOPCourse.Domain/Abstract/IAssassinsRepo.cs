using OOPCourse.Domain.Models;
using System.Collections.Generic;

namespace OOPCourse.Domain.Abstract
{
    public interface IAssassinsRepo
    {
        IEnumerable<Assassin> Assassins { get; }

        void Save();
    }
}
