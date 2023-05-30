namespace BooksLife.Web
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string HouseNumber { get; set; } = string.Empty;
        public string FlatNumber { get; set; } = string.Empty;
    }
}
