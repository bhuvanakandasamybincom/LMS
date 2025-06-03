using LibraryManagement.DbContexts;
using LibraryManagement.Interface;
using LibraryManagement.Model;

namespace LibraryManagement.Data
{
    public class AuthorData:IAuthorData
    {
        private readonly ApplicationDbContext _dbContext;
        public AuthorData(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Author GetAuthor(int id)
        {
            using (var dbContext = _dbContext)
            {
                var data = dbContext.Authors;
                return data.Find(id);
            }
        }
        public int AddAuthor(NewAuthor newAuthor) 
        {
            int AuthorId = 0;
            try
            {
                using (var dbContext = _dbContext)
                {
                    var author = new Author()
                    {
                        FirstName = newAuthor.FirstName,
                        LastName = newAuthor.LastName,
                    };
                    dbContext.Authors.Add(author); // adds the author to the DbSet in memory
                    dbContext.SaveChanges(); // commits the changes to the database
                    AuthorId = author.AuthorId;

                }
                
            }
            catch(Exception ex) { 

            }
            return AuthorId;


        }
        public void UpdateAuthor(Author author)
        {
            using (var dbContext = _dbContext)
            {
                
                var AuthorData = dbContext.Authors.Find(author.AuthorId); // retrieve the entity
                if(AuthorData!=null)
                {
                    AuthorData.FirstName = author.FirstName;
                    AuthorData.LastName = author.LastName; // amend properties
                }
                
                dbContext.SaveChanges(); // commit the changes
            }
            
        }
        public void DeleteAuthor(Author author)
        {
            using (var dbContext = _dbContext)
            {
                if(dbContext.Authors.Where(a => a.AuthorId == author.AuthorId).Count()>0)
                {
                    //To remove change track from DBContext
                    dbContext.Remove(author);
                    dbContext.Authors.Remove(author);
                    dbContext.SaveChanges(); // commit the changes
                }                
            }

                
            
        }


    }
}
