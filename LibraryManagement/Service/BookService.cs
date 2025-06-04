using LibraryManagement.Data;
using LibraryManagement.Interface;
using LibraryManagement.Model;
using System.Net.Http;
using System.Text.Json;

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
        public async Task<Book> GetBookdetailsService(int id)
        {
            string url = $"https://localhost:44362/api/v1/Book/getbookdetails?id={id}";
            HttpClient _httpClient = new HttpClient();
            var result = await _httpClient.GetAsync(url);

            result.EnsureSuccessStatusCode();
            var ContentString= result.Content.ReadAsStringAsync().Result;
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var results = JsonSerializer.Deserialize<Book>(ContentString, options);
            return results;
        }
        public async Task<List<Book>> GetBookByAuthorService(string Author)
        {
            return await _bookData.GetBookByAuthor(Author);
        }
        public async Task<List<Book>> GetMostBorrowedBooksService()
        {
            return await _bookData.GetMostBorrowedBooks();
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
