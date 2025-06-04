using LibraryManagement.DbContexts;
using LibraryManagement.Interface;
using LibraryManagement.Model;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LibraryManagement.Data
{
    public class BookData : IBookData
    {
        private readonly ApplicationDbContext _dbContext;
        public BookData(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Book> GetBook(int id)
        {
            using (var dbContext = _dbContext)
            {
                var data = dbContext.Books;
                return data.Find(id);
            }
        }
        public async Task<List<Book>> GetBookByAuthor(string AuthorName)
        {
            int AuthorId = Convert.ToInt16(AuthorName);
            Author author1 = new();
            using (var dbContext = _dbContext)
            {

                List<Book> books = new List<Book>();
                var query = dbContext.Books.GroupBy(b => b.AuthorId == AuthorId);

                foreach (var group in query)
                {
                    //Console.WriteLine(group.Key);
                    if(group.Key==true)
                    foreach (var book in group)
                    {
                        books.Add(book);
                    }
                };
                //Book book1 = books.FirstOrDefault();
                //using (var dbContext = _dbContext)
                //{
                //    var data = dbContext.Books.Find(1);
                //}
                return books;
            }
        }
        public int AddBook(NewBook newBook)
        {
            int BookId = 0;
            using (var dbContext = _dbContext)
            {
                var book = new Book()
                {
                    Title = newBook.Title,
                    ISBN = newBook.ISBN,
                    AuthorId = newBook.AuthorId,
                    CopiesAvailable = newBook.CopiesAvailable,
                };
                dbContext.Books.Add(book); // adds the Book to the DbSet in memory
                dbContext.SaveChanges(); // commits the changes to the database
                BookId=book.Id;
            }
            ;
            return BookId;
        }
        public void UpdateBook(Book book)
        {
            using (var dbContext = _dbContext)
            {
                var BookData = dbContext.Books.Find(book.Id); // retrieve the entity
                if (BookData != null)
                {
                    BookData.Title = book.Title;
                    BookData.ISBN = book.ISBN;
                    BookData.AuthorId = book.AuthorId;
                    BookData.CopiesAvailable = book.CopiesAvailable;
                    dbContext.SaveChanges(); // commit the changes
                }
            }
        }
        public void DeleteBook(Book book)
        {
            using (var dbContext = _dbContext)
            {
                if (dbContext.Books.Where(a => a.Id == book.Id).Count() > 0)
                {
                    dbContext.Remove(book);
                    dbContext.Books.Remove(book);
                    dbContext.SaveChanges(); // commit the changes
                }
            }
        }
        public async Task<List<Book>> GetMostBorrowedBooks()
        {

            using (var dbContext = _dbContext)
            {

                List<Book> books = new List<Book>();
                books = dbContext.Books.OrderByDescending(b => b.CopiesAvailable).Take(3).ToList();
                return books;
            }
        }
        




    }
}
