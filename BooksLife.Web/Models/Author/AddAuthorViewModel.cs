using System.ComponentModel.DataAnnotations;

namespace BooksLife.Web
{
    public class AddAuthorViewModel
    {
        public string? Firstname { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Lastname { get; set; } = string.Empty;
    }
}
