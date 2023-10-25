using AutoMapper;
using BooksLife.Core;

namespace BooksLife.Web
{
    public class ApplicationMappingProfile: Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<ReaderEntity, ReaderDto>()
                .ForMember(m => m.Country, c => c.MapFrom(s => s.Address.Country))
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.HouseNumber, c => c.MapFrom(s => s.Address.HouseNumber))
                .ForMember(m => m.FlatNumber, c => c.MapFrom(s => s.Address.FlatNumber));

            CreateMap<AddReaderDto, ReaderEntity>()
                .ForMember(m => m.Address, c => c.MapFrom(s => new AddressEntity()
                {
                    Country = s.Country,
                    City = s.City,
                    PostalCode = s.PostalCode,
                    Street = s.Street,
                    HouseNumber = s.HouseNumber,
                    FlatNumber = s.FlatNumber
                }));

            CreateMap<BorrowEntity, BorrowDto>();
            CreateMap<AddBorrowDto, BorrowEntity>();

            CreateMap<BookEntity, BookDto>()
                .ForMember(m => m.Title, c => c.MapFrom(s => s.BookTitle.Title))
                .ForMember(m => m.PublicationYear, c => c.MapFrom(s => s.BookTitle.PublicationYear))
                .ForMember(m => m.AuthorName, c => c.MapFrom(s => $"{s.BookTitle.Author.Firstname} {s.BookTitle.Author.Lastname}"));

            CreateMap<AddBookDto, BookEntity>()
                .ForMember(m => m.BookTitle, c => c.MapFrom(s => new BookTitleEntity()
                {
                    Title = s.Title,
                    PublicationYear = s.PublicationYear,
                    AuthorId = s.AuthorId
                }));

            CreateMap<AuthorEntity, AuthorDto>();

            CreateMap<AddAuthorDto, AuthorEntity>();
        }
    }
}
