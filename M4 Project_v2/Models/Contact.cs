using System.ComponentModel.DataAnnotations;
namespace M4_Project_v2.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter the Contacts First Name")]
        public string Fname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please Enter the Contacts Last Name")]
        public string Lname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Plese Enter a phone number")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please Enter a Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please Enter a Category")]
        public string Category { get; set; } = string.Empty;
    }
}
