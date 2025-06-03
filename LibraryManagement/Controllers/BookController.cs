using LibraryManagement.Data;
using LibraryManagement.Interface;
using LibraryManagement.Model;
using LibraryManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BookController : ControllerBase
    {
        public IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Get Book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBook/{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetBook(int id)
        {
            var result= await _bookService.GetBookService(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return BadRequest();
        }
        /// <summary>
        /// Get Book
        /// </summary>
        /// <param name="Author"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBooksbyAuthor")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetBookByAuthor(string Author)
        {
            var result = await _bookService.GetBookByAuthorService(Author);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return BadRequest();
        }
        /// <summary>
        /// Add Book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddBook")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AddBook(NewBook book)
        {
            var result = _bookService.AddBookService(book);
            if (result != 0)
            {
                return Ok(result);
            }
            else
                return BadRequest();
        }
        /// <summary>
        /// Update Book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateBook")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            var result = _bookService.UpdateBookService(book);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return BadRequest();
        }
        /// <summary>
        /// Delete Book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteBook")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteBook(Book book)
        {
            var result = _bookService.DeleteBookService(book);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return BadRequest();
        }

    }
}
