using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Model
{
    public class NewBook
    {
        [Required]
        [StringLength(150)]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        //public string Author { get; set; }
        //public Author Author { get; set; }
        public int AuthorId { get; set; }
        [Required]
        [StringLength(150)]
        [MaxLength(150)]
        public string ISBN { get; set; }
        [Required]
        public int CopiesAvailable { get; set; }
    }
}
