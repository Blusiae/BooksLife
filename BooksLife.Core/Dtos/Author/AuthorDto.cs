﻿namespace BooksLife.Core
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string? Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
    }
}
