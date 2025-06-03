using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Model
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage="User name is required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email ID is required")]
        public string Email { get; set; }
        public string SecurityStamp { get; set; }
        /// <summary>
        /// Gets or sets the name of the user. Maximum length is 30 characters.
        /// </summary>
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
