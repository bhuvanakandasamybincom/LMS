using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.DbContexts
{
    public class LibraryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "Server=DINESHKUMAR\\DEVSERVER;Database=LMS;User Id=sa;Password=Password#1;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(conn);

        }
    }
}
