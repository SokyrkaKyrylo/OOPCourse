using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCourse.Domain.Abstract
{
    public interface IDataRepo<T> where T : class
    {
        List<T> LoadListOfObjectFromRepo(string filePath);
    }
}
