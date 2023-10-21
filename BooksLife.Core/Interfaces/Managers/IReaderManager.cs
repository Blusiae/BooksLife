namespace BooksLife.Core
{
    public interface IReaderManager
    {
        Response Add(AddReaderDto readerDto);
        Response Remove(Guid Id);
        ReaderDto Get(Guid Id);
        List<ReaderDto> GetPage(int pageSize, int pageNumber, string? filterString, out int totalCount);
        List<ReaderDto> GetAll();
    }
}
