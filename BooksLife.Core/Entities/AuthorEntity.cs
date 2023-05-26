using System.ComponentModel.DataAnnotations;

namespace BooksLife.Core
{
    public class AuthorEntity: BaseEntity
    {
        public string Firstname { get; set; } = string.Empty;

        [Required]
        public string Lastname { get; set; }
    }
}
