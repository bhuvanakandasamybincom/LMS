using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.DbContexts
{
    public class LibraryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DataConfig dataConfig = new DataConfig();
            
            string conn = dataConfig.ConnectionString;
            optionsBuilder.UseSqlServer(conn);

        }
    }
}
