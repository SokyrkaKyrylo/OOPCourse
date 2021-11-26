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
            var dbContext = new ApplicationContext(options);
            if (dbContext.Database.EnsureCreated())
                DbManager.FeedDb(dbContext);
            else
                DbManager.RefershDb(dbContext);

            var repo = new NpcRepo(dbContext);
            var adventure = new Adventure(repo);

            adventure.Start();
        }
    }
}