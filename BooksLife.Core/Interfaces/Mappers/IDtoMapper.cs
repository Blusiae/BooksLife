namespace BooksLife.Core
{
    public interface IDtoMapper
    {
        AuthorEntity Map(AuthorDto Author);
        AuthorDto Map(AuthorEntity Author);
        IEnumerable<AuthorEntity> Map(IEnumerable<AuthorDto> Authors);
        IEnumerable<AuthorDto> Map(IEnumerable<AuthorEntity> Authors);
        ReaderEntity Map(ReaderDto Reader);
        ReaderDto Map(ReaderEntity Reader);
        IEnumerable<ReaderEntity> Map(IEnumerable<ReaderDto> Readers);
        IEnumerable<ReaderDto> Map(IEnumerable<ReaderEntity> Readers);
        BookEntity Map(BookDto Book);
        BookDto Map(BookEntity Book);
        IEnumerable<BookEntity> Map(IEnumerable<BookDto> Books);
        IEnumerable<BookDto> Map(IEnumerable<BookEntity> Books);
        BookTitleEntity Map(BookTitleDto BookTitle);
        BookTitleDto Map(BookTitleEntity BookTitle);
        IEnumerable<BookTitleEntity> Map(IEnumerable<BookTitleDto> BookTitles);
        IEnumerable<BookTitleDto> Map(IEnumerable<BookTitleEntity> BookTitles);
        BorrowEntity Map(BorrowDto Borrow);
        BorrowDto Map(BorrowEntity Borrow);
        IEnumerable<BorrowEntity> Map(IEnumerable<BorrowDto> Borrows);
        IEnumerable<BorrowDto> Map(IEnumerable<BorrowEntity> Borrows);
    }
}