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

    }
}
