using System.ComponentModel.DataAnnotations;

namespace TwistagBlazor.Models
{
    public class UserInformation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please write a name.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please write an Email.")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please write an age.")]
        public int? Age { get; set; }
    }
}
