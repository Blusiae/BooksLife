using BooksLife.Core;
using FluentAssertions;
using Xunit;

namespace BorrowsLife.Tests
{
    public class BorrowMappingTests
    {
        [Fact]
        public void ToDto_ForBorrowEntity_ShouldReturnBorrowDtoWithCorrectValues()
        {
            //arrange
            var borrowEntity = new BorrowEntity()
            {
                Id = Guid.NewGuid(),
                IsActive = true,
                BookId = Guid.NewGuid(),
                Book = new BookEntity()
                {
                    BookTitle = new BookTitleEntity()
                    {
                        Author = new AuthorEntity()
                    }
                },
                ReaderId = Guid.NewGuid(),
                Reader = new ReaderEntity()
                {
                    Address = new AddressEntity()
                },
                BorrowDate = DateTime.Now,
                ReturnDate = DateTime.Now
            };

            //act
            var borrowDto = borrowEntity.ToDto();

            //assert
            borrowDto.Should().BeOfType<BorrowDto>();
            borrowDto.Should().BeEquivalentTo(borrowEntity, options => options.ExcludingMissingMembers());
            borrowDto.Book.Should().BeOfType<BookDto>();
            borrowDto.Reader.Should().BeOfType<ReaderDto>();
        }

        [Fact]
        public void ToEntity_ForAddBorrowDto_ShouldReturnBorrowEntityWithCorrectValues()
        {
            //arrange
            var addBorrowDto = new AddBorrowDto()
            {
                IsActive = false,
                BookId = Guid.NewGuid(),
                ReaderId = Guid.NewGuid(),
                BorrowDate = DateTime.Now,
                ReturnDate = DateTime.Now
            };

            //act
            var borrowEntity = addBorrowDto.ToEntity();

            //assert
            borrowEntity.Should().BeOfType<BorrowEntity>();
            borrowEntity.Should().BeEquivalentTo(addBorrowDto, options => options.ExcludingMissingMembers());
        }

    }
}
