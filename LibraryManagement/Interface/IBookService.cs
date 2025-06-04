using LibraryManagement.Model;

namespace LibraryManagement.Interface
{
    public interface IBookService
    {
        public int AddBookService(NewBook book);
        public Task<Book> GetBookService(int id);
        public Task<List<Book>> GetBookByAuthorService(string Author);
        public Task<Book> GetBookdetailsService(int id);
        public string UpdateBookService(Book book);
        public string DeleteBookService(Book book);
        public Task<List<Book>> GetMostBorrowedBooksService();
    }
}
