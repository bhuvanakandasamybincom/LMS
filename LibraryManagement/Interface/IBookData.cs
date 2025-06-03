using LibraryManagement.Model;

namespace LibraryManagement.Interface
{
    public interface IBookData
    {
        public Task<Book> GetBook(int id);
        public Task<List<Book>> GetBookByAuthor(string Author);
        public int AddBook(NewBook book);
        public void UpdateBook(Book book);
        public void DeleteBook(Book book);
        public List<Book> GetMostBorrowedBooks();
    }
}
