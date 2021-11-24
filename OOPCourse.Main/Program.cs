using Autofac;
using Microsoft.EntityFrameworkCore;
using OOPCourse.Domain;
using OOPCourse.Domain.Abstract;
using OOPCourse.Domain.Concrete;

namespace OOPCourse.Main
{
    class Program
    {
                
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(@"Server=.\SQLEXPRESS;Database=OopCourse;Trusted_Connection=True;")
                .Options;
            var instance = new ApplicationContext(options);
            DbFeeder.FeedDb(instance);
            
            var repo = new NpcRepo(instance);
            var adventure = new Adventure(repo);
            
            adventure.Start();
        }
    }
}