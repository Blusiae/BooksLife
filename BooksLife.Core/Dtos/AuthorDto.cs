using System.ComponentModel.DataAnnotations;

namespace BooksLife.Core
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        [Required]
        public string Lastname { get; set; }
    }
}
