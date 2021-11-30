using Microsoft.EntityFrameworkCore;
using OOPCourse.Domain;

namespace OOPCourse.Main
{
    class Program
    {

        static void Main(string[] args)
        {
            ApplicationContext dbContext = null;
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
                var options = optionsBuilder
                    .UseSqlServer(@"Server=.\SQLEXPRESS;Database=oopcoursedb;Trusted_Connection=True;")
                    .Options;
                dbContext = new ApplicationContext(options);

                if (dbContext.Database.EnsureCreated())
                    DbManager.FeedDb(dbContext);
                else
                    DbManager.RefershDb(dbContext);
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("During loading something went wrong, try again");
                return;
            }

            var adventure = new Adventure(dbContext, 100, 1);
            adventure.Start();
        }
    }
}