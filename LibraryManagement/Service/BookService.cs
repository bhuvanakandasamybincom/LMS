using LibraryManagement.Data;
using LibraryManagement.Interface;
using LibraryManagement.Model;

namespace LibraryManagement.Service
{
    public class BookService : IBookService
    {
        public IBookData _bookData;

        public BookService(IBookData bookData)
        {
            _bookData = bookData;
        }
        
        public int AddBookService(NewBook book)
        {
            int BookId= _bookData.AddBook(book);
            return BookId;
        }
        public async Task<Book> GetBookService(int id)
        {
            return await _bookData.GetBook(id);
        }
        public async Task<List<Book>> GetBookByAuthorService(string Author)
        {
            return await _bookData.GetBookByAuthor(Author);
        }
        
        public string UpdateBookService(Book book)
        {
            _bookData.UpdateBook(book);
            return "Success";
        }
        public string DeleteBookService(Book book)
        {
            _bookData.DeleteBook(book);
            return "Success";
        }
    }
}
