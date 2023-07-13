namespace BooksLife.Core
{
    public interface IReaderManager
    {
        Response Add(AddReaderDto readerDto);
        Response Remove(Guid Id);
        ReaderDto Get(Guid Id);
        IEnumerable<ReaderDto> GetAll(int pageSize, int pageNumber, out int totalCount);
    }
}
