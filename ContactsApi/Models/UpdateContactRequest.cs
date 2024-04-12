using System.ComponentModel.DataAnnotations;

namespace ContactsApi.Models
{
    public class UpdateContactRequest
    {
        [Required(ErrorMessage = "FirstName parameter is required.")]
        [MaxLength(50, ErrorMessage = "FirstName must not be more than 50 characters.")]
        public required string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "LastName must not be more than 50 characters.")]
        public string? LastName { get; set;}

        [Required(ErrorMessage = "PhoneNumber parameter is required.")]
        [MinLength(7, ErrorMessage = "PhoneNumber must not be less 7 digits.")]
        [MaxLength(15, ErrorMessage = "PhoneNumber must not be more than 15 digits.")]
        [RegularExpression(@"^\+?\d{7,15}$", ErrorMessage = "Phone number format is invalid.")]
        public required string PhoneNumber { get; set;}
    }
}
