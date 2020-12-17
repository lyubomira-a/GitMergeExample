using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieManager.Models
{
    public class EditVM
    {
        public int Id { get; set; }

        [DisplayName("FirstName: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string FirstName { get; set; }

        [DisplayName("LastName: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string LastName { get; set; }

        [DisplayName("Username: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Username { get; set; }

        [DisplayName("Password: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Password { get; set; }
    }
}
