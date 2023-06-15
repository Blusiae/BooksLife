using BooksLife.Core;
using FluentAssertions;
using Xunit;

namespace ReadersLife.Tests
{
    public class ReaderMappingTests
    {
        [Fact]
        public void ToDto_ForReaderEntity_ShouldReturnReaderDtoWithCorrectValues()
        {
            //arrange
            var readerEntity = new ReaderEntity()
            {
                Id = Guid.NewGuid(),
                Firstname = "Firstname",
                Lastname = "Lastname",
                Birthdate = DateTime.Now,
                EmailAddress = "email@address.com",
                PhoneNumber = "000000000",
                AddressId = Guid.NewGuid(),
                Address = new AddressEntity()
                {
                    Country = "Country",
                    City = "City",
                    PostalCode = "00-000",
                    Street = "Street",
                    HouseNumber = "00a",
                    FlatNumber = "2"
                }
            };

            //act
            var readerDto = readerEntity.ToDto();

            //assert
            readerDto.Should().BeOfType<ReaderDto>();
            readerDto.Should().BeEquivalentTo(readerEntity, options => options.ExcludingMissingMembers());
            readerDto.Country.Should().Be("Country");
            readerDto.City.Should().Be("City");
            readerDto.PostalCode.Should().Be("00-000");
            readerDto.Street.Should().Be("Street");
            readerDto.HouseNumber.Should().Be("00a");
            readerDto.FlatNumber.Should().Be("2");
        }

    }
}
