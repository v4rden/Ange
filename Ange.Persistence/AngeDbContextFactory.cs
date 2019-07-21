namespace Ange.Persistence
{
    using Infrastructure;
    using Microsoft.EntityFrameworkCore;

    public class AngeDbContextFactory : DesignTimeDbContextFactoryBase<AngeDbContext>
    {
        protected override AngeDbContext CreateNewInstance(DbContextOptions<AngeDbContext> options)
        {
            return new AngeDbContext(options);
        }
    }
}