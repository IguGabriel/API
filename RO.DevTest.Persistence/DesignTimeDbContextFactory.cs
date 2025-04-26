using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RO.DevTest.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
    {
        public DefaultContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DefaultContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=rodevtest;Username=postgres;Password=12345;");


            return new DefaultContext(optionsBuilder.Options);
        }
    }
}
