namespace BooksLife.Core
{
    public static class EntityMapExtensions
    {
        public static AuthorEntity ToEntity(this AuthorDto authorDto)
        {
            return new AuthorEntity()
            {
                Id = authorDto.Id,
                Firstname = authorDto.Firstname,
                Lastname = authorDto.Lastname
            };
        }

        public static List<AuthorEntity> ToEntity(this IEnumerable<AuthorDto> authorDtos)
        {
            return authorDtos.Select(x => x.ToEntity()).ToList();
        }

        public static ReaderEntity ToEntity(this ReaderDto readerDto)
        {
            return new ReaderEntity()
            {
                Id = readerDto.Id,
                Firstname = readerDto.Firstname,
                Lastname = readerDto.Lastname,
                Birthdate = readerDto.Birthdate,
                EmailAddress = readerDto.EmailAddress,
                PhoneNumber = readerDto.PhoneNumber,
                Address = new AddressEntity()
                {
                    Country = readerDto.Country,
                    City = readerDto.City,
                    PostalCode = readerDto.PostalCode,
                    Street = readerDto.Street,
                    HouseNumber = readerDto.HouseNumber,
                    FlatNumber = readerDto.FlatNumber
                }
            };
        }

        public static List<ReaderEntity> ToEntity(this IEnumerable<ReaderDto> readerDtos)
        {
            return readerDtos.Select(x => x.ToEntity()).ToList();
        }
    }
}
