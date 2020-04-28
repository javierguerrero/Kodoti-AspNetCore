using System.ComponentModel.DataAnnotations;

namespace FrontEnd.ViewModels
{
    public class UserUpdateViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}