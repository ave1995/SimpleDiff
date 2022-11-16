using Microsoft.EntityFrameworkCore;

namespace SimpleDiff.Data
{
    public static class DbInitialiser
    {
        //docker-compose up -d
        //docker-compose down 
        public static void Initialize(DbContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            //DbContext.Database.Migrate();
        }

    }
}
