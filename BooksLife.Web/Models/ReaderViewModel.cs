namespace BooksLife.Web
{
    public class ReaderViewModel
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public AddressViewModel Address { get; set; }
    }
}
