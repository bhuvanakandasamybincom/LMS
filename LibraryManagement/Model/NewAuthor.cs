using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Model
{
    public class NewAuthor
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
    }
}
