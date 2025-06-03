using LibraryManagement.Data;
using LibraryManagement.DbContexts;
using LibraryManagement.Interface;
using LibraryManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Service
{
    public class AuthorService :IAuthorService
    {
        public IAuthorData _authorData;

        public AuthorService(IAuthorData authorData)
        {
            _authorData = authorData;
        }

        public int AddAuthorService(NewAuthor author)
        {
           int authorId= _authorData.AddAuthor(author);
            return authorId;
        }
        public Author GetAuthorData(int id)
        {
            return _authorData.GetAuthor(id);
        }
        public string UpdateAuthorService(Author author)
        {
             _authorData.UpdateAuthor(author);
            return "Success";
        }
        public string DeleteAuthorService(Author author)
        {
            _authorData.DeleteAuthor(author);
            return "Success";
        }
    }
}
