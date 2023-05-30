using System.ComponentModel.DataAnnotations;

namespace BooksLife.Web
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false)]
        public string Lastname { get; set; } = string.Empty;
    }
}
