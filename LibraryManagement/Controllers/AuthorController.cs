using LibraryManagement.Interface;
using LibraryManagement.Model;
using LibraryManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{

    [Authorize(Roles = UserRoles.Admin)]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthorController : ControllerBase
    {
        public IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        /// <summary>
        /// Get Author
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getAuthor/{authorId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAuthor(int authorId)
        {
          var result= _authorService.GetAuthorData(authorId);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return BadRequest();

        }
        /// <summary>
        /// Add Author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddAuthor")]
        public async Task<IActionResult> AddAuthor(NewAuthor author)
        {
            var result = _authorService.AddAuthorService(author);
            if (result != null && result != 0)
            {
                return Ok(result);
            }
            else
                return BadRequest();
        }
        /// <summary>
        /// Update Author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor(Author author)
        {
            var result = _authorService.UpdateAuthorService(author);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return BadRequest();
        }
        /// <summary>
        /// Delete Author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteAuthor")]
        public async Task<IActionResult> DeleteAuthor(Author author)
        {
            var result = _authorService.DeleteAuthorService(author);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return BadRequest();
        }
    }
}
