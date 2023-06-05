using BooksLife.Core;
using FluentAssertions;
using Xunit;

namespace BooksLife.Tests
{
    public class DtoMapperTests
    {
        [Fact]
        public void ForAuthorEntity_ShouldReturnAuthorDtoWithCorrectValues()
        {
            var authorEntity = new AuthorEntity()
            {
                Id = Guid.NewGuid(),
                Firstname = "AuthorFirstname",
                Lastname = "AuthorLastname"
            };

            var authorDto = authorEntity.ToDto();

            authorDto.Should().BeOfType<AuthorDto>();
            authorDto.Should().BeEquivalentTo(authorEntity, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void ForCollectionOfAuthorEntity_ShouldReturnListOfAuthorDtoWithCorrectValues()
        {
            var authorEntities = new List<AuthorEntity>()
            {
                new AuthorEntity()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "AuthorFirstname1",
                    Lastname = "AuthorLastname1"
                },
                new AuthorEntity()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "AuthorFirstname2",
                    Lastname = "AuthorLastname2"
                }
            };

            var authorDtos = authorEntities.ToDto();

            authorDtos.Should().BeOfType<List<AuthorDto>>();
            authorDtos.Should().BeEquivalentTo(authorEntities, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void ForReaderEntity_ShouldReturnReaderDtoWithCorrectValues()
        {
            var readerEntity = new ReaderEntity()
            {
                Id = Guid.NewGuid(),
                Firstname = "ReaderFirstname",
                Lastname = "ReaderLastname",
                Birthdate = DateTime.Now,
                EmailAddress = "email@address.com",
                Address = new AddressEntity()
                {
                    Id = Guid.NewGuid(),
                    Country = "AddressCountry",
                    City = "AddressCity",
                    PostalCode = "12345",
                    Street = "AddressStreet",
                    HouseNumber = "22"
                }
            };

            var readerDto = readerEntity.ToDto();

            readerDto.Should().BeOfType<ReaderDto>();
            readerDto.Should().BeEquivalentTo(readerEntity, options => options.ExcludingMissingMembers());
            readerDto.PhoneNumber.Should().BeNullOrEmpty();
            readerDto.Country.Should().Be("AddressCountry");
            readerDto.City.Should().Be("AddressCity");
            readerDto.PostalCode.Should().Be("12345");
            readerDto.Street.Should().Be("AddressStreet");
            readerDto.HouseNumber.Should().Be("22");
            readerDto.FlatNumber.Should().BeNullOrEmpty();
        }

        [Fact]
        public void ForCollectionOfReaderEntity_ShouldReturnListOfReaderDtoWithCorrectValues()
        {
            var readerEntities = new List<ReaderEntity>()
            {
                new ReaderEntity()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "ReaderFirstname",
                    Lastname = "ReaderLastname",
                    Birthdate = DateTime.Now,
                    EmailAddress = "email@address.com",
                    Address = new AddressEntity()
                    {
                        Id = Guid.NewGuid(),
                        Country = "AddressCountry",
                        City = "AddressCity",
                        PostalCode = "12345",
                        Street = "AddressStreet",
                        HouseNumber = "22"
                    }
                },
                new ReaderEntity()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "ReaderFirstname",
                    Lastname = "ReaderLastname",
                    Birthdate = DateTime.Now,
                    EmailAddress = "email@address.com",
                    Address = new AddressEntity()
                    {
                        Id = Guid.NewGuid(),
                        Country = "AddressCountry",
                        City = "AddressCity",
                        PostalCode = "12345",
                        Street = "AddressStreet",
                        HouseNumber = "22"
                    }
                }
            };

            var readerDtos = readerEntities.ToDto();

            readerDtos.Should().BeEquivalentTo(readerEntities, options => options.ExcludingMissingMembers());
            readerDtos.Should().BeOfType<List<ReaderDto>>();

            foreach (var readerDto in readerDtos)
            {
                readerDto.PhoneNumber.Should().BeNullOrEmpty();
                readerDto.Country.Should().Be("AddressCountry");
                readerDto.City.Should().Be("AddressCity");
                readerDto.PostalCode.Should().Be("12345");
                readerDto.Street.Should().Be("AddressStreet");
                readerDto.HouseNumber.Should().Be("22");
                readerDto.FlatNumber.Should().BeNullOrEmpty();
            }
        }
    }
}
