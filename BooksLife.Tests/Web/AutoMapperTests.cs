﻿using AutoMapper;
using BooksLife.Core;
using BooksLife.Web;
using FluentAssertions;
using Xunit;

namespace BooksLife.Tests.Web
{
    public class AutoMapperTests
    {
        private IMapper _mapper;

        public AutoMapperTests()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationMappingProfile());
            }));
        }

        [Fact]
        public void ValidateMappingConfigurationTest()
        {
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData("email@address.com", "1234567890", "FNumber")]
        [InlineData("email@address.com", null, "FNumber")]
        [InlineData(null, "1234567890", "FNumber")]
        [InlineData("email@address.com", "1234567890", null)]
        public void ReaderEntityToDtoMapping(string? emailAddress, string? phoneNumber, string? flatNumber)
        {
            var readerEntity = new ReaderEntity()
            {
                Id = Guid.Empty,
                Firstname = "Firstname",
                Lastname = "Lastname",
                EmailAddress = emailAddress,
                PhoneNumber = phoneNumber,
                Birthdate = DateTime.Now,
                Address = new AddressEntity()
                {
                    Id = Guid.Empty,
                    Country = "Country",
                    City = "City",
                    Street = "Street",
                    HouseNumber = "HNumber",
                    FlatNumber = flatNumber,
                    PostalCode = "00-000"
                }
            };

            var readerDto = _mapper.Map<ReaderDto>(readerEntity);

            readerDto.Should().BeOfType<ReaderDto>();
            readerDto.Should().BeEquivalentTo(readerEntity, options => options.ExcludingMissingMembers());
            readerDto.Country.Should().Be(readerEntity.Address.Country);
            readerDto.City.Should().Be(readerEntity.Address.City);
            readerDto.Street.Should().Be(readerEntity.Address.Street);
            readerDto.HouseNumber.Should().Be(readerEntity.Address.HouseNumber);
            readerDto.FlatNumber.Should().Be(readerEntity.Address.FlatNumber);
            readerDto.PostalCode.Should().Be(readerEntity.Address.PostalCode);
        }

        [Fact]
        public void ReaderEntityWithoutAddressToDtoMapping_ShouldNotThrowAnException()
        {
            var readerEntity = new ReaderEntity()
            {
                Id = Guid.Empty,
                Firstname = "Firstname",
                Lastname = "Lastname",
                EmailAddress = "email@address.com",
                PhoneNumber = "1234567890",
                Birthdate = DateTime.Now,
            };

            Action act = () => _mapper.Map<ReaderDto>(readerEntity);

            act.Should().NotThrow();
        }

        [Fact]
        public void BookEntityToDtoMapping()
        {
            var bookEntity = new BookEntity()
            {
                Id = Guid.Empty,
                EditionPublicationYear = 1000,
                Condition = BookCondition.Good,
                ConditionNote = "Note",
                BookTitle = new BookTitleEntity()
                {
                    Title = "Title",
                    PublicationYear = 1000,
                    Author = new AuthorEntity()
                    {
                        Firstname = "Firstname",
                        Lastname = "Lastname"
                    }
                }
            };

            var bookDto = _mapper.Map<BookDto>(bookEntity);

            bookDto.Should().BeOfType<BookDto>();
            bookDto.Should().BeEquivalentTo(bookEntity, options => options.ExcludingMissingMembers());
            bookDto.Title.Should().Be(bookEntity.BookTitle.Title);
            bookDto.PublicationYear.Should().Be(bookEntity.BookTitle.PublicationYear);
            bookDto.AuthorName.Should().Be($"{bookEntity.BookTitle.Author.Firstname} {bookEntity.BookTitle.Author.Lastname}");
        }
    }
}
