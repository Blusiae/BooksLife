using System.ComponentModel.DataAnnotations;

namespace BooksLife.Web
{
    public class ReaderViewModel
    {
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Firstname { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false)]
        public string Lastname { get; set; } = string.Empty;
        [Required]
        public DateTime Birthdate { get; set; }
        [EmailAddress] 
        public string EmailAddress { get; set; } = string.Empty;
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false)]
        public string Country { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false)]
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false)]
        public string Street { get; set; } = string.Empty;
        public string HouseNumber { get; set; } = string.Empty;
        public string FlatNumber { get; set; } = string.Empty;
    }
}
