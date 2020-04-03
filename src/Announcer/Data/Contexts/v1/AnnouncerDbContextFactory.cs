using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Announcer.Data.Contexts.v1
{
    public class AnnouncerDbContextFactory : IDesignTimeDbContextFactory<AnnouncerDbContext>
    {
        public AnnouncerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AnnouncerDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AnnouncerDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new AnnouncerDbContext(optionsBuilder.Options);
        }
    }
}