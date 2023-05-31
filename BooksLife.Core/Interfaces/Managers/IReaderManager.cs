namespace BooksLife.Core
{
    public interface IReaderManager
    {
        Response Add(ReaderDto readerDto);
        Response Remove(Guid Id);
        ReaderDto Get(Guid Id);
        List<ReaderDto> GetAllForList();
    }
}
