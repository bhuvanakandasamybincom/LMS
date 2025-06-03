using LibraryManagement.Model;

namespace LibraryManagement.Interface
{
    public interface IAuthorData
    {
        public Author GetAuthor(int id);
        public int AddAuthor(NewAuthor author);
        public void UpdateAuthor(Author author);
        public void DeleteAuthor(Author author);
    }
}
