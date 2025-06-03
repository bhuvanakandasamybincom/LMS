using LibraryManagement.Model;

namespace LibraryManagement.Interface
{
    public interface IAuthorService
    {
        public int AddAuthorService(NewAuthor author);
        public Author GetAuthorData(int id);
        public string UpdateAuthorService(Author author);
        public string DeleteAuthorService(Author author);
    }
}
