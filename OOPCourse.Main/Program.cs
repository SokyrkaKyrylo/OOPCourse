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
                .UseSqlServer(@"Server=ua00474;Database=oopcoursedb;Trusted_Connection=True;")
                .Options;
            var instance = new ApplicationContext(options);
            DbFeeder.FeedDb(instance);
            //var builder = new ContainerBuilder();
            //builder.Register(r => new NpcRepo(instance))
            //    .As<IAssassinsRepo>();
            //builder.Register(r => new NpcRepo(instance))
            //    .As<IThievesRepo>();
            //builder.Register(r => new NpcRepo(instance))
            //    .As<IBeggarsRepo>();
            //builder.Register(r => new NpcRepo(instance))
            //    .As<IFoolsRepo>();
            var repo = new NpcRepo(instance);
            var adventure = new Adventure(repo);
            adventure.Start();
        }
    }
}