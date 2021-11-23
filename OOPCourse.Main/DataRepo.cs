using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OOPCourse.Domain.Abstract;

namespace OOPCourse.Main
{
    //public class DataRepo<T> : IDataRepo<T> where T : class
    //{
    //    public List<T> LoadListOfObjectFromRepo(string filePath)
    //    {
    //        var jsonString = new StringBuilder();
    //        var _list = new List<T>();
    //        using var reader = new StreamReader(filePath);
    //        while (reader.Peek() != -1)
    //        {
    //            var temp = reader.ReadLine()?.TrimStart();
    //            if (temp.Equals("[") || temp.Equals("]"))
    //                continue;
    //            if (temp.Equals("},"))
    //            {
    //                jsonString.Append(temp.Replace(",", ""));
    //                _list.Add(JsonSerializer.Deserialize<T>(jsonString.ToString()));
    //                jsonString.Clear();
    //                temp = "";
    //            }
    //            jsonString.Append(temp);
    //        }
    //        return _list;
    //    }
    //}
}
