using LibraryManagement.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        /// <summary>
        /// Initializes a new instance of the ApplicationDbContext class with the specified DbContext options.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
            // The base constructor handles initializing the DbContext with the provided options.

        }
        //public string SQLConnectionSttring= configuration.GetConnectionString("MSSQLDBConnection");

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var s = System.Configuration;
        //    optionsBuilder.UseSqlServer(SQLConnectionSttring);
        //    Database.EnsureCreated();
        //}
        [Required]
        public DbSet<Author>? Authors { get; set; }
        [Required]
        public DbSet<Book>? Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //keys of Identity tables are mapped in OnModelCreating method of IdentityDbContext(base class)
            base.OnModelCreating(modelBuilder);
            
            //data seeding using HasData
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    AuthorId = 1,
                    FirstName = "William",
                    LastName = "Shakespeare"
                },
                new Author
                {
                    AuthorId = 2,
                    FirstName = "Peter",
                    LastName = "Albert"
                }
            );
            modelBuilder.Entity<Book>().HasData(
        new Book { Id = 1, AuthorId = 1, Title ="O God Beautyful", ISBN= "978-000-4658", CopiesAvailable=1},
        new Book { Id=2, AuthorId = 1, Title = "Hamlet", ISBN = "978-000-7543", CopiesAvailable = 1 },
        new Book { Id = 3, AuthorId = 1, Title = "King Lear", ISBN = "978-000-4213", CopiesAvailable = 1 },
        new Book { Id = 4, AuthorId = 1, Title = "Othello", ISBN = "978-000-9786", CopiesAvailable = 1 },
        new Book { Id = 5, AuthorId = 1, Title = "Sam Sheep", ISBN = "978-000-1247", CopiesAvailable = 1 }
           );

        }
    }
}
