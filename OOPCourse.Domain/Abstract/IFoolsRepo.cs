using OOPCourse.Domain.Models;
using System.Collections.Generic;

namespace OOPCourse.Domain.Abstract
{
    public interface IFoolsRepo
    {
        IEnumerable<Fool> Fools { get; }
    }
}
