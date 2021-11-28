using Microsoft.EntityFrameworkCore;
using OOPCourse.Domain;

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
            var dbContext = new ApplicationContext(options);

            if (dbContext.Database.EnsureCreated())
                DbManager.FeedDb(dbContext);
            else
                DbManager.RefershDb(dbContext);
            
            var adventure = new Adventure(dbContext);
            adventure.Start();
        }
    }
}