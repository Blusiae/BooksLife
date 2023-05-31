namespace BooksLife.Core
{
    public class AddressEntity : BaseEntity
    {
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string HouseNumber { get; set; } = string.Empty;
        public string? FlatNumber { get; set; } = string.Empty;

        public virtual IEnumerable<ReaderEntity> Readers { get; set; }
    }
}
