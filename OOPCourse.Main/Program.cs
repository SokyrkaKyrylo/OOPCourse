using System;
using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using OOPCourse.Domain;
using OOPCourse.Domain.Concrete;

namespace OOPCourse.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(@"Server=ua00474;Database=oopcoursedb;Trusted_Connection=True;")
                .Options;
            var context = new ApplicationContext(options);
            DbFeeder.FeedDb(context);
            var repo = new NpcRepo(context);
        }
    }
}