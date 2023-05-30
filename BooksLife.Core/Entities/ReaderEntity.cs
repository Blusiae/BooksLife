namespace BooksLife.Core
{
    public class ReaderEntity: BaseEntity
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public Guid AddressId { get; set; }
        public virtual AddressEntity Address { get; set; }
    }
}
