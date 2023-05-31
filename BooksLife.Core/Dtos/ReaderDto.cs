namespace BooksLife.Core
{
    public class ReaderDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string? EmailAddress { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string HouseNumber { get; set; } = string.Empty;
        public string? FlatNumber { get; set; } = string.Empty;
    }
}
