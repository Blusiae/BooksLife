﻿namespace BooksLife.Core
{
    public interface IBookManager
    {
        Response Add(AddBookDto bookDto);
        bool ChangeAvailability(Guid id);
        Response Remove(Guid id);
        List<BookDto> GetAll();
        BookDto Get(Guid id);
    }
}
